using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Persistence.Common.Mappings;
using PatiVerCore.Persistence.Context;

namespace PatiVerCore.Persistence.Repositories
{
    public class LocalDataRepository(ILogger<LocalDataRepository> logger, AppDBContext db) : ILocalDataRepository
    {
        private const string Success = "В локальной базе была найдена запись";
        private const string NotFound = "Пациент не найден";
        private const string MultipleFound = "Найдено больше одной записи";
        private const string Unexpected = "Произошла непредвиденная ошибка";

        public async Task<Result<PersonResponse>> GetDataByFioAsync(PersonFIO personData)
        {
            var birthdataFormatted = personData.ParsedBirthday?.ToString("yyyy.MM.dd");
            try
            {
                var localData = await db.FomsLocalData
                .AsNoTracking()
                .Where(x =>
                    x.Lastname!.ToLower() == personData.Surname.ToLower() &&
                    x.Firstname!.ToLower() == personData.Firstname.ToLower() &&
                    x.Patronymic!.ToLower() == personData.Patronymic.ToLower() &&
                    x.Birthdate == birthdataFormatted)
                .ToListAsync();

                //Запись не найдена
                logger.LogInformation(NotFound);
                if (localData.Count == 0) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                //Найдено больше одной записи
                logger.LogInformation(MultipleFound);
                if (localData.Count > 1) return Result<PersonResponse>.Failure(ErrorType.MultipleFound, MultipleFound);

                //Запись найдена
                logger.LogInformation(Success);
                return Result<PersonResponse>.Success(localData.First().ConvertToPersonResponse());
            }
            catch (Exception ex)
            {
                //Непредвиденная ошибка
                logger.LogInformation(ex, Unexpected);
                return Result<PersonResponse>.Failure(ErrorType.Unexpected, Unexpected);
            }
        }

        public async Task<Result<PersonResponse>> GetDataBySnilsAsync(PersonSnils personData)
        {
            try
            {
                var localData = await db.FomsLocalData
                .AsNoTracking()
                .Where(x => x.Snils == personData.Snils)
                .ToListAsync();

                //Запись не найдена
                logger.LogInformation(NotFound);
                if (localData.Count == 0) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                //Найдено больше одной записи
                logger.LogInformation(MultipleFound);
                if (localData.Count > 1) return Result<PersonResponse>.Failure(ErrorType.MultipleFound, NotFound);

                //Запись найдена
                logger.LogInformation(Success);
                return Result<PersonResponse>.Success(localData.First().ConvertToPersonResponse());
            }
            catch (Exception ex)
            {
                //Непредвиденная ошибка
                logger.LogInformation(ex, Unexpected);
                return Result<PersonResponse>.Failure(ErrorType.Unexpected, Unexpected);
            }
        }

        public async Task<Result<PersonResponse>> GetDataByPolisAsync(PersonPolis personData)
        {
            try
            {
                var localData = await db.FomsLocalData
                .AsNoTracking()
                .Where(x => x.Polis == personData.Polis)
                .ToListAsync();

                //Запись не найдена
                logger.LogInformation(NotFound);
                if (localData.Count == 0) return Result<PersonResponse>.Failure(ErrorType.NotFound, NotFound);

                //Найдено больше одной записи
                logger.LogInformation(MultipleFound);
                if (localData.Count > 1) return Result<PersonResponse>.Failure(ErrorType.MultipleFound, MultipleFound);

                //Запись найдена
                logger.LogInformation(Success);
                return Result<PersonResponse>.Success(localData.First().ConvertToPersonResponse());
            }
            catch (Exception ex)
            {
                //Непредвиденная ошибка
                logger.LogInformation(ex, Unexpected);
                return Result<PersonResponse>.Failure(ErrorType.Unexpected, Unexpected);
            }
        }
    }
}
