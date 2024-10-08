using MediatR;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Application.Features.Queries
{
    public class GetPatientDataByPolisQuery : IRequest<Result<PersonResponse>>
    {
        public PersonPolis PersonPolis { get; set; }
        public GetPatientDataByPolisQuery(PersonPolis personPolis)
        {
            PersonPolis = personPolis;
        }
    }

    internal class GetPatientDataByPolisHandler(
        ILogger<GetPatientDataByPolisHandler> logger,
        ICacheService cacheService,
        IFomsDataRepository fomsDataRepository,
        ILocalDataRepository localDataRepository) : IRequestHandler<GetPatientDataByPolisQuery, Result<PersonResponse>>
    {
        public async Task<Result<PersonResponse>> Handle(GetPatientDataByPolisQuery query, CancellationToken cancellationToken)
        {
            var personPolis = query.PersonPolis;
            var key = personPolis.Polis.Trim();

            //Проверка в КЭШ
            var cacheDataResult = await cacheService.GetCacheDataAsync(key);
            if (cacheDataResult.IsSuccess) return cacheDataResult; //Запись найдена в КЭШ

            try
            {
                //Проверка в ФОМС
                var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personPolis);

                if (fomsDataResult.IsSuccess)
                {
                    await cacheService.SetCacheDataAsync(key, fomsDataResult.Data); //Сохраняем в КЭШ
                }

                return fomsDataResult;
            }
            catch (TimeoutException ex)
            {
                //Если TimeOut, выполняем запрос в локальную базу
                logger.LogInformation(ex, ex.Message);
                return await localDataRepository.GetLocalDataAsync(personPolis);
            }
        }
    }
}
