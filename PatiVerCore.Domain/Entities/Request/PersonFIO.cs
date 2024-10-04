using PatiVerCore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PatiVerCore.Domain.Entities.Request
{
    public class PersonFIO : BaseRequestEnity
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Дата рождения с типом <see cref="DateTime"/>,
        /// чтобы можно было изменить формат
        /// </summary>
        public DateTime? ParsedBirthday { get; set; }

        public PersonFIO(
            string moId,
            string surname,
            string firstname,
            string patronymic,
            string birthday,
            string username,
            string password,
            bool isIPRAfirst,
            int mis)
            : base(moId, username, password, isIPRAfirst, mis)
        {
            Surname = surname;
            Firstname = firstname;
            Patronymic = patronymic;
            Birthday = birthday;
        }

        public bool IsValid(out List<string> validateErrors)
        {
            validateErrors = new List<string>();

            //Проверка имени
            if (string.IsNullOrEmpty(Surname))
            {
                validateErrors.Add("Отсутствует имя");
            }

            //Проверка фамилии
            if (string.IsNullOrEmpty(Firstname))
            {
                validateErrors.Add("Отсутствует Фамилия");
            }

            //Отчество не является оябязательным параметром
            //if (string.IsNullOrEmpty(Patronymic))
            //{
            //    validateErrors.Add("Отсутствует Фамилия");
            //}

            //Проверка даты рождения
            if (!string.IsNullOrEmpty(Birthday))
            {

                DateTime parseDate;
                if (DateTime.TryParse(Birthday, out parseDate)) //Стандартная проверка
                {
                    ParsedBirthday = parseDate;
                }
                else
                {
                    string[] possibleFormats = { "dd.MM.yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };
                    if (DateTime.TryParseExact(
                        Birthday,
                        possibleFormats,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out parseDate)) //Проверка на возможные форматы
                    {
                        ParsedBirthday = parseDate;
                    }
                    else
                    {
                        validateErrors.Add("Дата рождения неверного формата");
                    }
                }
            }
            else
            {
                validateErrors.Add("Отсутствует дата рождения");
            }

            //Возвращаем true, если ошибок нет
            return validateErrors.Count == 0;
        }
    }
}
