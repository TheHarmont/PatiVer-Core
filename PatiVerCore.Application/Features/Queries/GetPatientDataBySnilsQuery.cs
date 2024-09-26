﻿using MediatR;
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
    public class GetPatientDataBySnilsQuery : IRequest<Result<PersonResponse>>
    {
        public PersonSnils PersonSnils { get; set; }
        public GetPatientDataBySnilsQuery(PersonSnils personSnils)
        {
            PersonSnils = personSnils;
        }
    }

    internal class GetPatientDataBySnilsHandler(
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
            if (cacheDataResult.isSuccess) return cacheDataResult; //Запись найдена в КЭШ

            //Проверка в ФОМС
            var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personSnils);

            if (fomsDataResult.isSuccess)
            {
                await cacheService.SetCacheDataAsync(key, fomsDataResult.Data); //Сохраняем в КЭШ
                return fomsDataResult; //Запись найдена в КЭШ
            }

            //Если TimeOut, выполняем запрос в локальную базу
            if (fomsDataResult.ErrorType == ErrorType.TimeOut)
            {
                return await localDataRepository.GetDataBySnilsAsync(personSnils);
            }

            return fomsDataResult;
        }
    }
}
