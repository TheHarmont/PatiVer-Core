using MediatR;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
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
        ILogger<GetPatientDataByFioHandler> logger,
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
            if (cacheDataResult.IsSuccess) return cacheDataResult; //Запись найдена в КЭШ

            try
            {
                //Проверка в ФОМС
                var fomsDataResult = await fomsDataRepository.GetPersonInfoAsync(personFIO);

                if (fomsDataResult.IsSuccess)
                {
                    //Дополняем данными из запроса
                    var data = fomsDataResult.Data;
                    data.PatientData.Surname = personFIO.Surname;
                    data.PatientData.Name = personFIO.Firstname;
                    data.PatientData.Patronymic = personFIO.Patronymic;
                    data.PatientData.BirthDate = personFIO.ParsedBirthday;

                    await cacheService.SetCacheDataAsync(key, fomsDataResult.Data); //Сохраняем в КЭШ
                }

                return fomsDataResult;
            }
            catch (TimeoutException to_ex)
            {
                // Если TimeOut, выполняем запрос в локальную базу
                logger.LogInformation(to_ex, to_ex.Message);
                return await localDataRepository.GetLocalDataAsync(personFIO);
            }
        }
    }
}
