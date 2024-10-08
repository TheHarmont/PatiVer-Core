using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common;

namespace PatiVerCore.Application.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Возвращает данные из КЭШ, по указанному ключу
        /// </summary>
        public Task<Result<PersonResponse>> GetCacheDataAsync(string key);

        /// <summary>
        /// Помещает запись в КЭШ
        /// </summary>
        public Task SetCacheDataAsync(string key, PersonResponse response);
    }
}
