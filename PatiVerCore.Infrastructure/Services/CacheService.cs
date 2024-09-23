using Microsoft.Extensions.Caching.Distributed;
using PatiVerCore.Application.Interfaces;

namespace PatiVerCore.Infrastructure.Services
{
    public class CacheService(IDistributedCache _distributedCache) : ICacheService
    {
        public async Task<string?> GetCacheData(object id)
        {
            if (id is null) throw new ArgumentNullException(nameof(id), "Пустой идентификатор");

            try
            {
                var key = id.ToString() ?? throw new InvalidOperationException("Невозможно преобразовать ключ к типу string");

                //Получаем данные из кэш
                return await _distributedCache.GetStringAsync(key);
            }
            catch (Exception)
            {
                //TODO: Добавить логги
                throw;
            }
        }
    }
}
