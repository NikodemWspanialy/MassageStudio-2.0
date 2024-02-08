using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.DeleteMasage
{
    internal class DeleteMassageCommandHandler : IRequestHandler<DeleteMassageCommand>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IUserContext userContext;

        public DeleteMassageCommandHandler(IMassageStudioRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }
        public async Task<Unit> Handle(DeleteMassageCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null && currentUser.IsInRole("Masseur"))
            {
                try
                {
                    await repository.DeleteMassage(request.Id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Unit.Value;
        }
    }
}
