using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
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

        public EditMassageCommandHandler(IMassageStudioRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }
        public async Task<Unit> Handle(EditMassageCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if(currentUser != null && currentUser.IsInRole("Masseur"))
            {
                try
                {
                var massage = await repository.GetMassageByIsAsync(request.Massage.Id);
                    if(massage != null)
                    {
                        //zmiana

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
