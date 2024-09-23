using Microsoft.EntityFrameworkCore;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Common.Result.OperationResults;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Persistence.Context;

namespace PatiVerCore.Persistence.Repositories
{
    public class LocalDataRepository(AppDBContext db) : ILocalDataRepository
    {
        public async Task<Result<LocalData>> GetLocalDataByFioAsync(PersonFIO personData)
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

                if (localData.Count == 0) return new NotFoundResult<LocalData>($"Не найдена запись {personData.Surname} {personData.Firstname} {personData.Patronymic}, {personData.ParsedBirthday?.ToString()}");

                if (localData.Count > 1) return new MultipleFoundResult<LocalData>("Найдено больше одной записи");

                return new SuccessResult<LocalData>(localData.First());
            }
            catch (Exception ex)
            {
                return new UnexpectedResult<LocalData>($"Произошла непредвиденная ошибка: {ex.Message}");
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

                if (localData.Count == 0) return new NotFoundResult<LocalData>($"Не найдена запись: {personData.Snils}");

                if (localData.Count > 1) return new MultipleFoundResult<LocalData>("Найдено больше одной записи");

                return new SuccessResult<LocalData>(localData.First());
            }
            catch (Exception ex)
            {
                return new UnexpectedResult<LocalData>($"Произошла непредвиденная ошибка: {ex.Message}");
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


                if (localData.Count == 0) return new NotFoundResult<LocalData>($"Не найдена запись: {personData.Polis}");

                if (localData.Count > 1) return new MultipleFoundResult<LocalData>("Найдено больше одной записи");

                return new SuccessResult<LocalData>(localData.First());
            }
            catch (Exception ex)
            {
                return new UnexpectedResult<LocalData>($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}
