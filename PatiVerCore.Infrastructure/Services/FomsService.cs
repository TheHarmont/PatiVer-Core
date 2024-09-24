using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Infrastructure.Mappings;

namespace PatiVerCore.Infrastructure.Services
{
    public class FomsService(IFomsDataRepository fomsRepository) : IFomsService
    {
        public async Task<Result<PersonResponse>> GetPatientInfo<T>(T personData) where T : class
        {
            var result = await fomsRepository.GetPersonInfoAsync(personData);

            if (!result.isSuccess)
            {
                return await Result<PersonResponse>.FailureAsync(result.ErrorType, result.Data.ConvertToPersonResponse(), result.Message);
            }

            return await Result<PersonResponse>.SuccessAsync(result.Data.ConvertToPersonResponse());
            
        }
    }
}
