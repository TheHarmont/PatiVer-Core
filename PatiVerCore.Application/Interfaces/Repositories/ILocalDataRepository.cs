using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Application.Interfaces.Repositories
{
    public interface ILocalDataRepository
    {
        /// <summary>
        /// Возвращает данные пациента из БД, отфильтрованные по входным данным.
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <returns>
        /// 
        /// </returns>
        public Task<Result<LocalData>> GetLocalDataByFioAsync(PersonFIO data);

        /// <summary>
        /// Возвращает данные пациента из БД, отфильтрованные по входным данным.
        /// </summary>
        /// <param name="polis">Полис</param>
        /// <returns>
        /// <see cref="LocalData"/>
        public Task<Result<LocalData>> GetDataByPolisAsync(PersonPolis data);

        /// <summary>
        /// Возвращает данные пациента из БД, отфильтрованные по входным данным.
        /// </summary>
        /// <param name="snils">Снилс</param>
        /// <returns>
        /// <see cref="LocalData"/>
        public Task<Result<LocalData>> GetDataBySnilsAsync(PersonSnils data);

    }
}
