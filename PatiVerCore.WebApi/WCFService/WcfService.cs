using MediatR;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Features.Queries;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.WebApi.WCFService
{
    public class WcfService(
        ILogger<WcfService> logger,
        IMediator mediator) : IWcfService
    {
        private const string RequestFIO = "Начата обработка запроса по ФИО";
        private const string RequestSnils = "Начата обработка запроса по Снилс";
        private const string RequestPolis = "Начата обработка запроса по Полис";
        private const string InvalidModel = "Не удалось обработать входные данные";
        private const string RequestIsFinished = "Ответ направлен";


        public PersonResponse GetPersonInfo_FIO(string moId, string surname, string firstname, string patronymic, string birthday, string username, string password, bool isIPRAfirst, int mis)
        {
            logger.LogInformation(RequestFIO);
            var personFio = new PersonFIO(moId, surname, firstname, patronymic, birthday, username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personFio.IsValid(out List<string> validateErrors))
            {
                logger.LogInformation(InvalidModel + $": {validateErrors.First()}");
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "-1"
                };
            }

            var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataByFioQuery(personFio))).Result;

            if (personDataResult.isSuccess)
            {
                logger.LogInformation(RequestIsFinished);
                return personDataResult.Data;
            } 
            else
            {
                logger.LogInformation(RequestIsFinished);
                return new PersonResponse()
                {
                    MessageData = "Пациент не найден, либо найдено больше одного",
                    SearchResult = "-1"
                };
            }
        }

        public PersonResponse GetPersonInfo_SNILS(string moId, string snils, string username, string password, bool isIPRAfirst, int mis)
        {
            logger.LogInformation(RequestSnils);
            var personSnils = new PersonSnils(moId, snils, username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personSnils.IsValid(out List<string> validateErrors))
            {
                logger.LogInformation(InvalidModel + $": {validateErrors.First()}");
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "0"
                };
            }

            var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataBySnilsQuery(personSnils))).Result;

            if (personDataResult.isSuccess)
            {
                logger.LogInformation(RequestIsFinished);
                return personDataResult.Data;
            }
            else
            {
                logger.LogInformation(RequestIsFinished);
                return new PersonResponse()
                {
                    MessageData = "Пациент не найден, либо найдено больше одного",
                    SearchResult = "-1"
                };
            }
        }

        public PersonResponse GetPersonInfo_Polis(string moId, string polis, string username, string password, bool isIPRAfirst, int mis)
        {
            logger.LogInformation(RequestPolis);
            var personPolis = new PersonPolis(moId, polis, username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personPolis.IsValid(out List<string> validateErrors))
            {
                logger.LogInformation(InvalidModel + $": {validateErrors.First()}");
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "0"
                };
            }

            var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataByPolisQuery(personPolis))).Result;

            if (personDataResult.isSuccess)
            {
                logger.LogInformation(RequestIsFinished);
                return personDataResult.Data;
            }
            else
            {
                logger.LogInformation(RequestIsFinished);
                return new PersonResponse()
                {
                    MessageData = "Пациент не найден, либо найдено больше одного",
                    SearchResult = "-1"
                };
            }
        }
    }
}
