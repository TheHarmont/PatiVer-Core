using MediatR;
using NLog;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Features.Queries;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.WebApi.Common;

namespace PatiVerCore.WebApi.WCFService
{
    public class WcfService(
        IHttpContextAccessor HCA,
        ILogger<WcfService> logger,
        IMediator mediator) : IWcfService
    {
        private const string RequestStarted = "Начало выполнения запроса";
        private const string RequestIsFinished = "Ответ направлен";
        private const string BasicFailedResponse = "Пациент не найден, либо найдено больше одного";


        public PersonResponse GetPersonInfo_FIO(string moId, string surname, string firstname, string patronymic, string birthday, string username, string password, bool isIPRAfirst, int mis)
        {
            try
            {
                using (ScopeContext.PushProperty("RequestIp", HCA?.HttpContext?.GetRequestIp()))
                using (ScopeContext.PushProperty("TraceIdentifier", HCA?.HttpContext?.GetTraceIdentifier()))
                using (ScopeContext.PushProperty("RequestMethod", HCA?.HttpContext?.GetRequestMethod()))
                using (ScopeContext.PushProperty("RequestEndpoint", HCA?.HttpContext?.GetRequestEndpoint()))
                {

                    logger.LogInformation(RequestStarted + ": ФИО");
                    var personFio = new PersonFIO(moId, surname, firstname, patronymic, birthday, username, password, isIPRAfirst, mis);

                    //Проверяем модель
                    if (!personFio.IsValid(out List<string> validateErrors))
                    {
                        logger.LogInformation(validateErrors.First());
                        return ReturnFailureResponse(validateErrors.First(), "0");
                    }

                    var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataByFioQuery(personFio))).Result;

                    if (personDataResult.IsSuccess)
                    {
                        logger.LogInformation(RequestIsFinished);
                        return personDataResult.Data;
                    }
                    else
                    {
                        logger.LogInformation(RequestIsFinished);
                        return ReturnFailureResponse(BasicFailedResponse, "0");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, ex.Message);
                return ReturnFailureResponse(BasicFailedResponse, "0");
            }
            
        }

        public PersonResponse GetPersonInfo_SNILS(string moId, string snils, string username, string password, bool isIPRAfirst, int mis)
        {
            try
            {
                using (ScopeContext.PushProperty("RequestIp", HCA?.HttpContext?.GetRequestIp()))
                using (ScopeContext.PushProperty("TraceIdentifier", HCA?.HttpContext?.GetTraceIdentifier()))
                using (ScopeContext.PushProperty("RequestMethod", HCA?.HttpContext?.GetRequestMethod()))
                using (ScopeContext.PushProperty("RequestEndpoint", HCA?.HttpContext?.GetRequestEndpoint()))
                {
                    logger.LogInformation(RequestStarted + ": Снилс");
                    var personSnils = new PersonSnils(moId, snils, username, password, isIPRAfirst, mis);

                    //Проверяем модель
                    if (!personSnils.IsValid(out List<string> validateErrors))
                    {
                        logger.LogInformation(validateErrors.First());
                        return ReturnFailureResponse(validateErrors.First(), "0");
                    }

                    var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataBySnilsQuery(personSnils))).Result;

                    if (personDataResult.IsSuccess)
                    {
                        logger.LogInformation(RequestIsFinished);
                        return personDataResult.Data;
                    }
                    else
                    {
                        logger.LogInformation(RequestIsFinished);
                        return ReturnFailureResponse(BasicFailedResponse, "0");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, ex.Message);
                return ReturnFailureResponse(BasicFailedResponse, "0");
            }
        }

        public PersonResponse GetPersonInfo_Polis(string moId, string polis, string username, string password, bool isIPRAfirst, int mis)
        {
            try
            {
                using (ScopeContext.PushProperty("RequestIp", HCA?.HttpContext?.GetRequestIp()))
                using (ScopeContext.PushProperty("TraceIdentifier", HCA?.HttpContext?.GetTraceIdentifier()))
                using (ScopeContext.PushProperty("RequestMethod", HCA?.HttpContext?.GetRequestMethod()))
                using (ScopeContext.PushProperty("RequestEndpoint", HCA?.HttpContext?.GetRequestEndpoint()))
                {
                    logger.LogInformation(RequestStarted + ": Полис");
                    var personPolis = new PersonPolis(moId, polis, username, password, isIPRAfirst, mis);

                    //Проверяем модель
                    if (!personPolis.IsValid(out List<string> validateErrors))
                    {
                        logger.LogInformation(validateErrors.First());
                        return ReturnFailureResponse(validateErrors.First(), "0");
                    }

                    var personDataResult = Task.Run(async () => await mediator.Send(new GetPatientDataByPolisQuery(personPolis))).Result;

                    if (personDataResult.IsSuccess)
                    {
                        logger.LogInformation(RequestIsFinished);
                        return personDataResult.Data;
                    }
                    else
                    {
                        logger.LogInformation(RequestIsFinished);
                        return ReturnFailureResponse(BasicFailedResponse, "0");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, ex.Message);
                return ReturnFailureResponse(BasicFailedResponse, "0");
            }
        }

        private static PersonResponse ReturnFailureResponse(string messageData, string searchResult)
        {
            return new PersonResponse()
            {
                MessageData = messageData,
                SearchResult = searchResult
            };
        }
    }
}
