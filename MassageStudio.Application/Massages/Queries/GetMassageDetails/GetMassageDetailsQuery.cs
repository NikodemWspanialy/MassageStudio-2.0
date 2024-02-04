using MassageStudio.Application.Massages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Queries.GetMassageDetails
{
    public class GetMassageDetailsQuery : IRequest<MassageDetailsDto>
    {
        public string Id { get; set; }
        public GetMassageDetailsQuery(string id)
        {
            Id = id;
        }
    }
}
