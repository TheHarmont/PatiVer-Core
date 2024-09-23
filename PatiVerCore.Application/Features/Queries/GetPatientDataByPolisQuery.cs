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
    public class GetPatientDataByPolisQuery : IRequest<PersonResponse>
    {
        public PersonPolis PersonPolis { get; set; }
        public GetPatientDataByPolisQuery(PersonPolis personPolis)
        {
            PersonPolis = personPolis;
        }
    }

    internal class GetPatientDataByPolisHandler : IRequestHandler<GetPatientDataByPolisQuery, PersonResponse>
    {
        public async Task<PersonResponse> Handle(GetPatientDataByPolisQuery query, CancellationToken cancellationToken)
        {

        }
    }
}
