using MassageStudio.Application.ApplicationUser;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Commands.CreateMassageEmpty
{
    internal class CreateMassageEmptyCommandHander : IRequestHandler<CreateMassageEmptyCommand, string?>
    {
        private readonly IMassageTermRepository repository;
        private readonly IUserContext userContext;

        public CreateMassageEmptyCommandHander(IMassageTermRepository repository, IUserContext userContext)
        {
            this.repository = repository;
            this.userContext = userContext;
        }
        public async Task<string?> Handle(CreateMassageEmptyCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null && currentUser.IsInRole("Masseur"))
            {
                var id = currentUser.Id;
                var name = currentUser.Name;
                var lastname = currentUser.LastName;
                var massage = new Domain.Entities.Massage(id, name, lastname, request.Date)
                {
                    Id = Guid.NewGuid().ToString()   
                };
                
                var createdId = await repository.CreateMassageEmptyAsync(massage);
                return createdId;

            }
            throw new Exception("User do not have permission to this action");
        }
    }
}
