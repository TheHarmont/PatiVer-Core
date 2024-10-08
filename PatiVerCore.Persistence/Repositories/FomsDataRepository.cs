using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Domain.Entities.Response;
using PatiVerCore.Persistence.Common.Mappings;
using PatiVerCore.Persistence.Connected.FomsConnectService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatiVerCore.Persistence.Repositories
{
    public class FomsDataRepository : IFomsDataRepository
    {
        private const string Success = "В ФОМС была найдена запись";
        private const string NotFound = "Пациент не найден";

        private readonly MiacBDZServiceIdentClient _client;
        private readonly ILogger<FomsDataRepository> _logger;

        public FomsDataRepository(ILogger<FomsDataRepository> logger)
        {
            _client = new MiacBDZServiceIdentClient();
            _logger = logger;
        }

        public async Task<Result<PersonResponse>> GetPersonInfoAsync<T>(T request) where T : class
        {
            ResponseData data = new();

            //Запрос по ФИО
            if (request is PersonFIO fio)
                data = await _client.GetPersonInfo_FIOAsync(
                    fio.MoId,
                    fio.Surname,
                    fio.Firstname,
                    fio.Patronymic,
                    fio.ParsedBirthday?.ToString("yyyy-MM-dd"),
                    fio.Username,
                    fio.Password,
                    fio.IsIPRAfirst,
                    fio.MIS);

            //Запрос по снилс
            if (request is PersonSnils snils)
                data = await _client.GetPersonInfo_SNILSAsync(
                    snils.MoId,
                    snils.Snils,
                    snils.Username,
                    snils.Password,
                    snils.IsIPRAfirst,
                    snils.MIS);

            //Запрос по снисл
            if (request is PersonPolis polis)
                data = await _client.GetPersonInfo_PolisAsync(
                    polis.MoId,
                    polis.Polis,
                    polis.Username,
                    polis.Password,
                    polis.IsIPRAfirst,
                    polis.MIS);
            


            _logger.LogInformation(NotFound);
            if (data is null) return Result<PersonResponse>.Failure(NotFound);

            _logger.LogInformation(Success + $": Result {data.Result}");
            return Result<PersonResponse>.Success(data.ConvertToPersonResponse());
        }
    }
}
