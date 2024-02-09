using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Commands.AddRoleToUser
{
    internal class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand>
    {
        private readonly IUserContext userContext;
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AddRoleToUserCommandHandler(IUserContext userContext, UserManager<Domain.Entities.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userContext = userContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var CurrectUser = await userContext.GetCurrentUserAsync();
            if(CurrectUser != null && CurrectUser.IsInRole("Admin"))
            {
                var user = await userManager.FindByIdAsync(request.Id);
                if (user != null) 
                {
                    var role = await roleManager.FindByNameAsync(request.Role);
                    if (role != null && role.Name != null)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }
            return Unit.Value;
        }
    }
}
