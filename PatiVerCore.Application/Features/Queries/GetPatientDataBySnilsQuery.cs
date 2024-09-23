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
    public class GetPatientDataBySnilsQuery : IRequest<PersonResponse>
    {
        public PersonFIO PersonFio { get; set; }
        public GetPatientDataBySnilsQuery(PersonFIO personFio)
        {
            personFio = personFio;
        }
    }

    internal class GetPatientDataBySnilsHandler : IRequestHandler<GetPatientDataBySnilsQuery, PersonResponse>
    {
        public async Task<PersonResponse> Handle(GetPatientDataBySnilsQuery query, CancellationToken cancellationToken)
        {

        }
    }
}
