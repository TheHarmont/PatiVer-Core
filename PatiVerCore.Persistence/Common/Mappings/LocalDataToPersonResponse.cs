using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Entities;
using PatiVerCore.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Persistence.Common.Mappings
{
    public static class LocalDataToPersonResponse
    {
        /// <summary>
        /// Преобразует объект LocalData в PersonResponse
        /// </summary>
        public static PersonResponse ConvertToPersonResponse(this LocalData data)
        {
            if (data == null) return null;

            var fomsData = new ResponseData();
            PersonResponse result = new PersonResponse()
            {
                SearchResult = fomsData.Result,
                PatientData = PatientData.FromFomsData(new PersonData()),
                AttachmentData = PatientAttachment.FromFomsData(new AttachmentData()),
                PolisData = Polis.FromFomsData(new PolisData()),
                MessageData = fomsData.Message
            };

            //Наполнение данными
            result.SearchResult = "1";
            result.AttachmentData.CodeMO = data.CodeMO.ToString();

            result.PatientData.Name = data.Firstname;
            result.PatientData.Surname = data.Lastname;
            result.PatientData.Patronymic = data.Patronymic;
            if (DateTime.TryParse(data.Birthdate, out DateTime personBirthDate)) result.PatientData.BirthDate = personBirthDate;
            if (DateTime.TryParse(data.BeginDate, out DateTime attachBeginDate)) result.AttachmentData.BeginDate = attachBeginDate;
            if (DateTime.TryParse(data.EndDate, out DateTime attachEndDate)) result.AttachmentData.EndDate = attachEndDate;

            result.PatientData.ENP = data.Polis;
            result.PatientData.Snils = data.Snils;

            return result;
        }

    }
}
