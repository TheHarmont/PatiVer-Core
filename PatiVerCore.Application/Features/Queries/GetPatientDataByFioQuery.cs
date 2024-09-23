using MediatR;
using PatiVerCore.Domain.Entities.Request;
using PatiVerCore.Domain.Entities.Response;
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
            personFio = personFio;
        }
    }

    internal class GetPatientDataByFioHandler : IRequestHandler<GetPatientDataByFioQuery, PersonResponse>
    {
        public async Task<PersonResponse> Handle(GetPatientDataByFioQuery query, CancellationToken cancellationToken)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
