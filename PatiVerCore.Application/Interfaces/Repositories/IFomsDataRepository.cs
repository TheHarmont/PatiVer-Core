using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Application.Interfaces.Repositories
{
    public interface IFomsDataRepository
    {
        /// <summary>
        /// Возвращает задачу, содержащую данные о результате опреации получения данных из ФОМС
        /// </summary>
        /// <param name="request">
        /// <para><see cref="PersonFIO"/> данные с ФИО</para>
        /// <para><see cref="PersonSnils"/> данные со Снилс</para>
        /// <para><see cref="PersonPolis"/> данные с Полис</para>
        /// </param>
        /// <returns><see cref="PersonResponse"/> - данные о пациенте</returns>
        public Task<Result<PersonResponse>> GetPersonInfoAsync<T>(T request) where T : class;
    }
}