using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Commands.UnreserveTerm
{
    internal class UnreserveTermCommandHandler : IRequestHandler<UnreserveTermCommand, IdentityResult>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IUserContext userContext;

        public UnreserveTermCommandHandler(IMassageStudioRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }
        public async Task<IdentityResult> Handle(UnreserveTermCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null)
            {
                var massage = await repository.GetMassageByIsAsync(request.Id);
                if (massage != null && !massage.Free)
                {
                    massage.Free = true;
                    massage.ClientId = null;
                    massage.ClientName = null;
                    massage.ClientLastName = null;
                    await repository.SaveChangesAsync();
                    return IdentityResult.Success;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            throw new Exception("Nor permission");
        }
    }
}
