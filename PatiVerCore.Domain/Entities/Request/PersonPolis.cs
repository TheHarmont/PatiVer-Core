using PatiVerCore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Entities.Request
{
    public class PersonPolis : BaseRequestEnity
    {
        public string Polis {  get; set; }

        public PersonPolis(string moId, string polis, string username, string password, bool isIPRAfirst, int mis)
            : base(moId, username, password, isIPRAfirst, mis)
        {
            Polis = polis;
        }

        public bool IsValid(out List<string> validateErrors)
        {
            validateErrors = new List<string>();

            //Проверка полис
            if (string.IsNullOrEmpty(Polis))
            {
                validateErrors.Add("Отсутствует полис");
            }

            //Возвращаем true, если ошибок нет
            return validateErrors.Count == 0;
        }
    }
}
