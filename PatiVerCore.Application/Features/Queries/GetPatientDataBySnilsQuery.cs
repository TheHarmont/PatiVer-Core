using MediatR;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Application.Features.Queries
{
    public class GetPatientDataBySnilsQuery : IRequest<Result<PersonResponse>>
    {
        public PersonSnils PersonSnils { get; set; }
        public GetPatientDataBySnilsQuery(PersonSnils personSnils)
        {
            PersonSnils = personSnils;
        }
    }

    internal class GetPatientDataBySnilsHandler(
        ILogger<GetPatientDataBySnilsHandler> logger,
        ICacheService cacheService,
        IFomsDataRepository fomsDataRepository,
        ILocalDataRepository localDataRepository) : IRequestHandler<GetPatientDataBySnilsQuery, Result<PersonResponse>>
    {
        public async Task<Result<PersonResponse>> Handle(GetPatientDataBySnilsQuery query, CancellationToken cancellationToken)
        {
            var personSnils = query.PersonSnils;
            var key = personSnils.Snils.Trim();

            //Проверка в КЭШ
            var cacheDataResult = await cacheService.GetCacheDataAsync(key);
            if (cacheDataResult.IsSuccess) return cacheDataResult; //Запись найдена в КЭШ

            try
            {
                //Проверка в ФОМС
                var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personSnils);

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
                return await localDataRepository.GetLocalDataAsync(personSnils);
            }
        }
    }
}
