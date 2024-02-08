using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.EditMassage
{
    internal class EditMassageCommandHandler : IRequestHandler<EditMassageCommand>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IUserContext userContext;
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;

        public EditMassageCommandHandler(IMassageStudioRepository repository, IUserContext userContext, UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            this.repository = repository;
            this.userContext = userContext;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(EditMassageCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if(currentUser != null && currentUser.IsInRole("Masseur"))
            {
                try
                {
                var massage = await repository.GetMassageByIsAsync(request.Id);
                    if(massage != null)
                    {
                        massage.Date = request.Date;
                        if(request.Free && !massage.Free)
                        {
                            massage.Free = true;
                            massage.ClientId = null;
                            massage.ClientName = null;
                            massage.ClientLastName = null;
                        }
                        else if (!request.Free && massage.Free)
                        {
                            massage.Free = false;
                            massage.ClientName = "Zmienione recznie";
                            massage.ClientLastName = "Zmienione recznie";
                        }
                        await repository.SaveChangesAsync();
                        return Unit.Value;
                    }
                }
                catch
                {
                    throw new Exception("Can not edit massage");
                }
            }
            throw new Exception("User do not have permission to this action");
        }
    }
}
