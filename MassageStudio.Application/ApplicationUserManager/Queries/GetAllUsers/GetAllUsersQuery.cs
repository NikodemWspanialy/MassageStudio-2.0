using MassageStudio.Application.ApplicationUser.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<ApplicationUserListedDto>>
    {
    }
}
