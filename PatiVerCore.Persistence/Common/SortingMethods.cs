using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Request;

namespace PatiVerCore.Persistence.Common
{
    internal static class SortingMethods
    {
        /// <summary>
        /// Сортировка данных по их типу
        /// </summary>
        /// <returns>Данные, отсортированные по ФИО, Полис или Снилс</returns>
        public static IQueryable<LocalData> SortByDataType<T>(this IQueryable<LocalData> query, T personData) where T : class
        {
            if (personData is PersonFIO fio)
            {
                var birthdataFormatted = fio.ParsedBirthday?.ToString("yyyy.MM.dd");

                return query.Where(x =>
                x.Lastname!.ToLower() == fio.Surname.ToLower() &&
                x.Firstname!.ToLower() == fio.Firstname.ToLower() &&
                x.Patronymic!.ToLower() == fio.Patronymic.ToLower() &&
                x.Birthdate == birthdataFormatted);
            }

            if (personData is PersonSnils snils) return query.Where(x => x.Snils == snils.Snils);

            if (personData is PersonPolis polis) return query.Where(x => x.Polis == polis.Polis);

            return query;
        }
    }
}
