using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Domain.Common;
using System.Text.Json;

namespace PatiVerCore.Infrastructure.Services
{
    public class CacheService(ILogger<CacheService> logger,IDistributedCache distributedCache) : ICacheService
    {
        private const string GetSuccess = "Запись была найдена в КЭШ";
        private const string SetSuccess = "Запись была помещена в КЭШ";
        private const string NotFound = "Не найдена запись в КЭШ";
        private const string InvalidDeserialize = "Не смогли извлечь запись из КЭШ";
        private const string Unexpected = "Произошла непредвиденная ошибка";

        //Настройки redis 
        private static readonly DistributedCacheEntryOptions redisOptions
            = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = (TimeSpan.FromDays(4)), //Через 4 дня запись будет удалена
                SlidingExpiration = (TimeSpan.FromDays(2))  //Если в течение 2-х дней к записи не обратились, то запись будет удалена
            };

        //Настройки сериализации
        private static readonly JsonSerializerOptions serializeOptions 
            = new JsonSerializerOptions 
            { 
                IncludeFields = true  //Чтобы выполнялась сериализация полей, а не только свойств
            };

        public async Task<Result<PersonResponse>> GetCacheDataAsync(string key)
        {
            try
            {
                //Получаем данные из кэш
                var cacheJson = await distributedCache.GetStringAsync(key);

                if (string.IsNullOrEmpty(cacheJson))
                {
                    logger.LogInformation(NotFound);
                    return Result<PersonResponse>.Failure();
                }

                //Десериализуем строку в объект
                var response = JsonSerializer.Deserialize<PersonResponse>(cacheJson, serializeOptions);

                if (response is null)
                {
                    logger.LogInformation(InvalidDeserialize);
                    return Result<PersonResponse>.Failure();
                }

                logger.LogInformation(GetSuccess);
                return Result<PersonResponse>.Success(response);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, Unexpected);
                return Result<PersonResponse>.Failure();
            }
        }

        public async Task SetCacheDataAsync(string key, PersonResponse response)
        {
            try
            {
                // сериализуем данные в строку в формате json
                var responseString = JsonSerializer.Serialize(response, serializeOptions);
                // сохраняем строковое представление объекта в формате json в кэш на 2 минуты
                await distributedCache.SetStringAsync(key, responseString, redisOptions);

                logger.LogInformation(SetSuccess);
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, Unexpected);
            }
            
        }
    }
}
