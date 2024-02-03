using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.UserIsInRoles
{
    internal class UserIsInRoleQueryHandler : IRequestHandler<UserIsInRolesQuery, bool>
    {
        private readonly IUserContext userContext;

        public UserIsInRoleQueryHandler(IUserContext userContext)
        {
            this.userContext = userContext;
        }
        public async Task<bool> Handle(UserIsInRolesQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser == null)
            {
                return false;
            }
            foreach (var role in request.Roles)
            {
                if (currentUser.IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
