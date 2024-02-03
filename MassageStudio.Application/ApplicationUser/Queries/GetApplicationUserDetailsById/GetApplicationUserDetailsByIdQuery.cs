using MassageStudio.Application.ApplicationUser.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.GetApplicationUserDetails
{
    public class GetApplicationUserDetailsByIdQuery : IRequest<ApplicationUserDetailsDto>
    {
        public string Id { get; set; }
        public GetApplicationUserDetailsByIdQuery(string id)
        {
            Id = id;
        }
    }
}
