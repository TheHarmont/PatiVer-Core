using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PatiVerCore.Application.Interfaces
{
    public interface ICacheService
    {
        /// <summary>
        /// Выполняет поиск записи в КЭШ по ключу
        /// </summary>
        /// <param name="key">Ключ обращения</param>
        /// <returns>Задачу, представляющую асинхронную операцию получения 
        /// результата, содержащего модель <see cref="PersonResponse"/>
        /// <para><see cref="SuccessResult"/></para> 
        /// <para><see cref="NotFoundResult"/></para> 
        /// <para><see cref="InvalidResult"/></para> 
        /// </returns>
        public Task<Result<PersonResponse>> GetCacheDataAsync(string key);

        /// <summary>
        /// Сохраняет запись в кэш
        /// </summary>
        /// <param name="key">Ключь для поиска</param>
        /// <param name="response">Объект</param>
        public Task SetCacheDataAsync(string key, PersonResponse response);
    }
}
