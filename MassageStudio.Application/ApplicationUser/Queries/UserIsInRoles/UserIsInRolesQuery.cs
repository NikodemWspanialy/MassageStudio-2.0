using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.UserIsInRoles
{
    public class UserIsInRolesQuery : IRequest<bool>
    {
       public IEnumerable<string> Roles {  get; set; }
        public UserIsInRolesQuery(IEnumerable<string> roles)
        {
            Roles = roles;
        }
        public UserIsInRolesQuery(string role)
        {
            Roles = new List<string>() { role};
        }
    }
}
