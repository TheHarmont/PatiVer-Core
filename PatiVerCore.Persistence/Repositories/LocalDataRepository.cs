using Microsoft.EntityFrameworkCore;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Persistence.Context;

namespace PatiVerCore.Persistence.Repositories
{
    public class LocalDataRepository(AppDBContext db) : ILocalDataRepository
    {
        public async Task<Result<LocalData>> GetDataByFioAsync(PersonFIO personData)
        {
            try
            {
                var birthdataFormatted = personData.ParsedBirthday?.ToString("yyyy.MM.dd");

                var localData = await db.FomsLocalData
                    .AsNoTracking()
                    .Where(x =>
                        x.Lastname!.ToLower() == personData.Surname.ToLower() &&
                        x.Firstname!.ToLower() == personData.Firstname.ToLower() &&
                        x.Patronymic!.ToLower() == personData.Patronymic.ToLower() &&
                        x.Birthdate == birthdataFormatted)
                    .ToListAsync();

                if (localData.Count == 0) return await Result<LocalData>.FailureAsync(
                    ErrorType.NotFound ,
                    $"Не найдена запись {personData.Surname} {personData.Firstname} {personData.Patronymic}, {personData.ParsedBirthday?.ToString()}");

                if (localData.Count > 1) return await Result<LocalData>.FailureAsync(
                    ErrorType.MultipleFound,
                    "Найдено больше одной записи");

                return await Result<LocalData>.SuccessAsync(localData.First());
            }
            catch (Exception ex)
            {
                return await Result<LocalData>.FailureAsync(
                    ErrorType.Unexpected,
                    $"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }

        public async Task<Result<LocalData>> GetDataBySnilsAsync(PersonSnils personData)
        {
            try
            {
                var localData = await db.FomsLocalData
                    .AsNoTracking()
                    .Where(x => x.Snils == personData.Snils)
                    .ToListAsync();

                if (localData.Count == 0) return await Result<LocalData>.FailureAsync(
                    ErrorType.NotFound,
                    $"Не найдена запись: {personData.Snils}");

                if (localData.Count > 1) return await Result<LocalData>.FailureAsync(
                    ErrorType.MultipleFound,
                    "Найдено больше одной записи");

                return await Result<LocalData>.SuccessAsync(localData.First());
            }
            catch (Exception ex)
            {
                return await Result<LocalData>.FailureAsync(
                    ErrorType.Unexpected,
                    $"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }

        public async Task<Result<LocalData>> GetDataByPolisAsync(PersonPolis personData)
        {
            try
            {
                var localData = await db.FomsLocalData
                    .AsNoTracking()
                    .Where(x => x.Polis == personData.Polis)
                    .ToListAsync();

                if (localData.Count == 0) return await Result<LocalData>.FailureAsync(
                    ErrorType.NotFound,
                    $"Не найдена запись: {personData.Polis}");

                if (localData.Count > 1) return await Result<LocalData>.FailureAsync(
                    ErrorType.MultipleFound,
                    "Найдено больше одной записи");

                return await Result<LocalData>.SuccessAsync(localData.First());
            }
            catch (Exception ex)
            {
                return await Result<LocalData>.FailureAsync(
                    ErrorType.Unexpected,
                    $"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}
