using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Commands.DeleteUser
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;
        private readonly IUserContext userContext;

        public DeleteUserCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager, IUserContext userContext)
        {
            this.userManager = userManager;
            this.userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null && currentUser.IsInRole("Admin"))
            {
                var user = await userManager.FindByIdAsync(request.Id);
                if(user != null)
                {
                    await userManager.DeleteAsync(user);
                }
                else
                {
                    throw new Exception("User is null there!");
                }
            }
            return Unit.Value;
        }
    }
}
