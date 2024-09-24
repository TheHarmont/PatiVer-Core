using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Domain.Common
{
    public abstract class BaseRequestEnity
    {
        /// <summary>
        /// Идентификатор МО
        /// </summary>
        public string? MoId { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsIPRAfirst { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MIS { get; set; }

        public BaseRequestEnity(string moId, string username, string password, bool isIPRAfirst, int mis)
        {
            MoId = moId;
            Username = username;
            Password = password;
            IsIPRAfirst = isIPRAfirst;
            MIS = mis;
        }
    }
}
