using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.UserActions.Commands.ReserveTerm
{
    internal class ReserveTermCommandHandler : IRequestHandler<ReserveTermCommand, IdentityResult>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IUserContext userContext;

        public ReserveTermCommandHandler(IMassageStudioRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }
        public async Task<IdentityResult> Handle(ReserveTermCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null)
            {
                var massage = await repository.GetMassageByIsAsync(request.Id);
                if (massage != null && massage.Free)
                {
                    var type = await repository.GetTypeByNameAsync(request.Type);
                    if (type == null)
                    {
                        throw new NullReferenceException(nameof(type));
                    }
                    massage.TypeName = type.Name;
                    massage.Free = false;
                    massage.ClientId = currentUser.Id;
                    massage.ClientName = currentUser.Name;
                    massage.ClientLastName = currentUser.LastName;

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

