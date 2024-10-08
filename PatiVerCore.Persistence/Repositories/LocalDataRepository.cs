using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Persistence.Common;
using PatiVerCore.Persistence.Common.Mappings;
using PatiVerCore.Persistence.Context;

namespace PatiVerCore.Persistence.Repositories
{
    public class LocalDataRepository(ILogger<LocalDataRepository> logger, AppDBContext db) : ILocalDataRepository 
    {
        private const string Success = "В локальной базе была найдена запись";
        private const string NotFound = "Пациент не найден";
        private const string MultipleFound = "Найдено больше одной записи";

        public async Task<Result<PersonResponse>>GetLocalDataAsync<T>(T personData) where T : class
        {
            var localData = await db.FomsLocalData
                .AsNoTracking().
                SortByDataType(personData).
                ToListAsync();

            //Запись не найдена
            logger.LogInformation(NotFound);
            if (localData.Count == 0) return Result<PersonResponse>.Failure(NotFound);

            //Найдено больше одной записи
            logger.LogInformation(MultipleFound);
            if (localData.Count > 1) return Result<PersonResponse>.Failure(MultipleFound);

            //Запись найдена
            logger.LogInformation(Success);
            return Result<PersonResponse>.Success(localData.First().ConvertToPersonResponse());
        }
    }
}
