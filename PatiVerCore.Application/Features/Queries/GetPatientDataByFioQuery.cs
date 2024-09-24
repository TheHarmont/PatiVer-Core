using MediatR;
using PatiVerCore.Application.DTOs;
using PatiVerCore.Application.Interfaces.Repositories;
using PatiVerCore.Domain.Common.Result;
using PatiVerCore.Domain.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatiVerCore.Application.Features.Queries
{
    public class GetPatientDataByFioQuery : IRequest<PersonResponse>
    {
        public PersonFIO PersonFio { get; set; }
        public GetPatientDataByFioQuery(PersonFIO personFio)
        {
            PersonFio = personFio;
        }
    }

    internal class GetPatientDataByFioHandler(ILocalDataRepository localDataRepository) : IRequestHandler<GetPatientDataByFioQuery, PersonResponse>
    {
        public async Task<PersonResponse> Handle(GetPatientDataByFioQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var sd = await localDataRepository.GetDataByFioAsync(query.PersonFio);
                switch (sd.ErrorType)
                {
                    case ErrorType.Ok:
                        break;
                    case ErrorType.Invalid:
                        break;
                    case ErrorType.Unexpected:
                        break;
                    default:
                        return new UnexpectedResult<>
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
