using PatiVerCore.Domain.Common;
using PatiVerCore.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Request
{
    public class PersonSnils : BaseRequestEnity
    {
        public string Snils {  get; set; }

        public PersonSnils(string moId, string snils, string username, string password, bool isIPRAfirst, int mis) 
            : base(moId, username, password,isIPRAfirst, mis)
        {
            Snils = snils;
        }

        public bool IsValid(out List<string> validateErrors)
        {
            validateErrors = new List<string>();

            //Проверка полис
            if (string.IsNullOrEmpty(Snils))
            {
                validateErrors.Add("Отсутствует полис");
            }

            //Возвращаем true, если ошибок нет
            return validateErrors.Count == 0;
        }
    }
}
