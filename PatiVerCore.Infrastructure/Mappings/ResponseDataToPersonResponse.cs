using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatiVerCore.Infrastructure.Mappings
{
    public static class ResponseDataToPersonResponse
    {
        /// <summary>
        /// Преобразует объект ResponseData в PersonResponse
        /// </summary>
        public static PersonResponse ConvertToPersonResponse(this ResponseData responseData)
        {
            return new PersonResponse()
            {
                SearchResult = responseData.Result,
                PatientData = PatientData.FromFomsData(responseData.personData),
                AttachmentData = PatientAttachment.FromFomsData(responseData.attachmentData),
                PolisData = Polis.FromFomsData(responseData.polisData),
                MessageData = responseData.Message
            };
        }
    }
}
