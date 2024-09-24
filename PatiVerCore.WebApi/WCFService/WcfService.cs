using MediatR;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Features.Queries.QueryByFio;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.WebApi.WCFService
{
    public class WcfService(IMediator mediator) : IWcfService
    {
        public PersonResponse GetPersonInfo_FIO(string moId, string surname, string firstname, string patronymic, string birthday, string username, string password, bool isIPRAfirst, int mis)
        {
            var personFio = new PersonFIO(moId, surname, firstname, patronymic, birthday, username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personFio.IsValid(out List<string> validateErrors))
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "-1"
                };

            var result = Task.Run(async () => await mediator.Send(new GetPatientDataByFioQuery(personFio))).Result;

            return result;
        }

        public PersonResponse GetPersonInfo_SNILS(string moId, string snils, string username, string password, bool isIPRAfirst, int mis)
        {
            var personSnils = new PersonSnils(moId, snils,  username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personSnils.IsValid(out List<string> validateErrors))
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "-1"
                };

            var result = Task.Run(async () => await mediator.Send(new GetPatientDataBySnilsQuery(personSnils))).Result;

            return result;
        }

        public PersonResponse GetPersonInfo_Polis(string moId, string polis, string username, string password, bool isIPRAfirst, int mis)
        {
            var personPolis = new PersonPolis(moId, polis, username, password, isIPRAfirst, mis);

            //Проверяем модель
            if (!personPolis.IsValid(out List<string> validateErrors))
                return new PersonResponse()
                {
                    MessageData = validateErrors.First(),
                    SearchResult = "-1"
                };

            var result = Task.Run(async () => await mediator.Send(new GetPatientDataByPolisQuery(personPolis))).Result;

            return result;
        }
    }
}
