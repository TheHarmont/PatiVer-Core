using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Domain.Entities.Response;

namespace PatiVerCore.Application.Interfaces.Repositories
{
    public interface IFomsDataRepository
    {
        /// <summary>
        /// Выполняет запрос в ФОМС, используя данные пациента
        /// </summary>
        /// <typeparam name="T">
        /// <para><see cref="PersonFIO"/> - модель содержащая данные ФИО</para>
        /// <para><see cref="PersonSnils"/> - модель содержащая данные снилс</para>
        /// <para><see cref="PersonPolis"/> - модель содержащая данные полис</para>
        /// </typeparam>
        /// <param name="request"></param>
        /// <returns>
        /// <para><see cref="SuccessResult"/></para> 
        /// <para><see cref="NotFoundResult"/></para> 
        /// <para><see cref="MultipleFoundResult"/></para> 
        /// <para><see cref="InvalidResult"/></para> 
        /// <para><see cref="UnexpectedResult"/></para> 
        /// <para><see cref="TimeOut"/></para> 
        /// </returns>
        public Task<Result<PersonResponse>> GetPersonInfoAsync<T>(T request) where T : class;
    }
}