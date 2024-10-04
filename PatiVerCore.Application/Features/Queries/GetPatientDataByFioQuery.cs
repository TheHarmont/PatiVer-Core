using MediatR;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Application.Features.Queries
{
    public record GetPatientDataByFioQuery : IRequest<Result<PersonResponse>>
    {
        public PersonFIO PersonFio { get; set; }
        public GetPatientDataByFioQuery(PersonFIO personFio)
        {
            PersonFio = personFio;
        }
    }

    internal class GetPatientDataByFioHandler(
        ICacheService cacheService,
        IFomsDataRepository fomsDataRepository,
        ILocalDataRepository localDataRepository) : IRequestHandler<GetPatientDataByFioQuery, Result<PersonResponse>>
    {
        public async Task<Result<PersonResponse>> Handle(GetPatientDataByFioQuery query, CancellationToken cancellationToken)
        {
            var personFIO = query.PersonFio;
            var key = personFIO.Firstname?.ToLower().Trim() + personFIO.Surname?.ToLower().Trim() + personFIO.Patronymic?.ToLower().Trim() + personFIO.ParsedBirthday?.ToString("yyyy-mm-dd");


            //Проверка в КЭШ
            var cacheDataResult = await cacheService.GetCacheDataAsync(key);
            if (cacheDataResult.isSuccess) return cacheDataResult; //Запись найдена в КЭШ

            //Проверка в ФОМС
            var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personFIO);

            if (fomsDataResult.isSuccess)
            {
                //Дополняем данными из запроса
                var data = fomsDataResult.Data;
                data.PatientData.Surname = personFIO.Surname;
                data.PatientData.Name = personFIO.Firstname;
                data.PatientData.Patronymic = personFIO.Patronymic;
                data.PatientData.BirthDate = personFIO.ParsedBirthday;

                await cacheService.SetCacheDataAsync(key, fomsDataResult.Data); //Сохраняем в КЭШ
                return fomsDataResult; //Запись найдена в КЭШ
            }

            //Если TimeOut, выполняем запрос в локальную базу
            if (fomsDataResult.ErrorType == ErrorType.TimeOut)
            {
                return await localDataRepository.GetDataByFioAsync(personFIO);
            }

            return fomsDataResult;
        }
    }
}
