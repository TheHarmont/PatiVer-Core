using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Domain.Entities.Response;
using PatiVerCore.Persistence.Connected.FomsConnectService;

namespace PatiVerCore.Persistence.Repositories
{
    public class FomsDataRepository : IFomsDataRepository
    {
        private readonly MiacBDZServiceIdentClient client;

        public FomsDataRepository()
        {
            client = new MiacBDZServiceIdentClient();
        }

        public async Task<Result<ResponseData>> GetPersonInfoAsync<T>(T request) where T : class
        {
            try
            {
                if (request is PersonFIO fio) 
                {
                    var data = await client.GetPersonInfo_FIOAsync(
                        fio.MoId,
                        fio.Surname,
                        fio.Firstname,
                        fio.Patronymic,
                        fio.ParsedBirthday?.ToString("yyyy-MM-dd"),
                        fio.Username,
                        fio.Password,
                        fio.IsIPRAfirst,
                        fio.MIS);

                    if(data.Result == "0") return await Result<ResponseData>.FailureAsync(ErrorType.NotFound,"Запись не найдена");
                    if(data.Result == "1") return await Result<ResponseData>.SuccessAsync(data);
                    //if(data.Result == "2") return; неизвестный код
                    if(data.Result == "3") return await Result<ResponseData>.FailureAsync(ErrorType.MultipleFound, "Найдено больше одной записи");

                    return await Result<ResponseData>.FailureAsync(ErrorType.Unexpected, "Непредвиденный результат");
                }
                    

                if (request is PersonSnils snils)
                {
                    var data = await client.GetPersonInfo_SNILSAsync(
                        snils.MoId,
                        snils.Snils,
                        snils.Username,
                        snils.Password,
                        snils.IsIPRAfirst,
                        snils.MIS);

                    if (data.Result == "0") return await Result<ResponseData>.FailureAsync(ErrorType.NotFound, "Запись не найдена");
                    if (data.Result == "1") return await Result<ResponseData>.SuccessAsync(data);
                    //if(data.Result == "2") return; неизвестный код
                    if (data.Result == "3") return await Result<ResponseData>.FailureAsync(ErrorType.MultipleFound, "Найдено больше одной записи");

                    return await Result<ResponseData>.FailureAsync(ErrorType.Unexpected, "Непредвиденный результат");
                }

                if (request is PersonPolis polis)
                {
                    var data = await client.GetPersonInfo_PolisAsync(
                        polis.MoId,
                        polis.Polis,
                        polis.Username,
                        polis.Password,
                        polis.IsIPRAfirst,
                        polis.MIS);

                    if (data.Result == "0") return await Result<ResponseData>.FailureAsync(ErrorType.NotFound, "Запись не найдена");
                    if (data.Result == "1") return await Result<ResponseData>.SuccessAsync(data);
                    //if(data.Result == "2") return; неизвестный код
                    if (data.Result == "3") return await Result<ResponseData>.FailureAsync(ErrorType.MultipleFound, "Найдено больше одной записи");

                    return await Result<ResponseData>.FailureAsync(ErrorType.Unexpected, "Непредвиденный результат");
                }

                return await Result<ResponseData>.FailureAsync(ErrorType.Invalid, "Неизвестная модель");
            }
            catch (Exception ex)
            {
                return await Result<ResponseData>.FailureAsync(ErrorType.Unexpected, $"Произошла непредвиденная ошибка: {ex.Message}");
            }

        }
    }
}
