using MediatR;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (cacheDataResult.isSuccess) return cacheDataResult; //Запись найдена в КЭШ

            //Проверка в ФОМС
            var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personPolis);

            if (fomsDataResult.isSuccess)
            {
                await cacheService.SetCacheDataAsync(key, fomsDataResult.Data); //Сохраняем в КЭШ
                return fomsDataResult; //Запись найдена в КЭШ
            }

            //Если TimeOut, выполняем запрос в локальную базу
            if (fomsDataResult.ErrorType == ErrorType.TimeOut)
            {
                return await localDataRepository.GetDataByPolisAsync(personPolis);
            }

            return fomsDataResult;
        }
    }
}
