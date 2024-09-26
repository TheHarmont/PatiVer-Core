using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Domain.Entities.Response;
using PatiVerCore.Persistence.Common.Mappings;
using PatiVerCore.Persistence.Connected.FomsConnectService;

namespace PatiVerCore.Persistence.Repositories
{
    public class FomsDataRepository : IFomsDataRepository
    {
        private const string Success = "В ФОМС была найдена запись";
        private const string NotFound = "Пациент не найден";
        private const string Unexpected = "Произошла непредвиденная ошибка";
        private const string TimeOut = "Ошибка TimeOut";
        private const string Invalid = "Невозможно обработать входящую модель";

        private readonly MiacBDZServiceIdentClient _client;
        private readonly ILogger<FomsDataRepository> _logger;

        public FomsDataRepository(ILogger<FomsDataRepository> logger)
        {
            _client = new MiacBDZServiceIdentClient();
            _logger = logger;
        }

        public async Task<Result<PersonResponse>> GetPersonInfoAsync<T>(T request) where T : class
        {
            try
            {
                //Запрос по ФИО
                if (request is PersonFIO fio) 
                {
                    var data = await _client.GetPersonInfo_FIOAsync(
                        fio.MoId,
                        fio.Surname,
                        fio.Firstname,
                        fio.Patronymic,
                        fio.ParsedBirthday?.ToString("yyyy-MM-dd"),
                        fio.Username,
                        fio.Password,
                        fio.IsIPRAfirst,
                        fio.MIS);

                    _logger.LogInformation(NotFound);
                    if(data is null) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                    _logger.LogInformation(Success + $": Result {data.Result}");
                    return  Result<PersonResponse>.Success(data.ConvertToPersonResponse());
                }
                    
                //Запрос по снилс
                if (request is PersonSnils snils)
                {
                    var data = await _client.GetPersonInfo_SNILSAsync(
                        snils.MoId,
                        snils.Snils,
                        snils.Username,
                        snils.Password,
                        snils.IsIPRAfirst,
                        snils.MIS);

                    _logger.LogInformation(NotFound);
                    if (data is null) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                    _logger.LogInformation(Success + $": Result {data.Result}");
                    return Result<PersonResponse>.Success(data.ConvertToPersonResponse());
                }

                //Запрос по снисл
                if (request is PersonPolis polis)
                {
                    var data = await _client.GetPersonInfo_PolisAsync(
                        polis.MoId,
                        polis.Polis,
                        polis.Username,
                        polis.Password,
                        polis.IsIPRAfirst,
                        polis.MIS);

                    _logger.LogInformation(NotFound);
                    if (data is null) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                    _logger.LogInformation(Success + $": Result {data.Result}");
                    return Result<PersonResponse>.Success(data.ConvertToPersonResponse());
                }

                _logger.LogInformation(Invalid);
                return Result<PersonResponse>.Failure(ErrorType.Invalid, Invalid);
            }
            catch (TimeoutException to_ex)
            {
                _logger.LogInformation(to_ex, TimeOut);
                return Result<PersonResponse>.Failure(ErrorType.TimeOut, TimeOut);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, Unexpected);
                return Result<PersonResponse>.Failure(ErrorType.Unexpected, Unexpected);
            }
        }
    }
}
