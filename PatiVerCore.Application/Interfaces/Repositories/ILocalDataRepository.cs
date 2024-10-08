using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Application.Interfaces.Repositories
{
    public interface ILocalDataRepository
    {
        /// <summary>
        /// Возвращает задачу, содержашую результат выполнения операции получения данных из локальной базы
        /// </summary>
        /// <param name="personData">
        /// <para><see cref="PersonFIO"/> данные с ФИО</para>
        /// <para><see cref="PersonSnils"/> данные со Снилс</para>
        /// <para><see cref="PersonPolis"/> данные с Полис</para>
        /// </param>
        /// <returns><see cref="PersonResponse"/> - данные о пациенте</returns>
        public Task<Result<PersonResponse>> GetLocalDataAsync<T>(T personData) where T : class;
    }
}
