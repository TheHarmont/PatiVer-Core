using PatiVerCore.Application.DTOs;
using PatiVerCore.Domain.Entities.Response;

namespace PatiVerCore.Persistence.Common.Mappings
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
