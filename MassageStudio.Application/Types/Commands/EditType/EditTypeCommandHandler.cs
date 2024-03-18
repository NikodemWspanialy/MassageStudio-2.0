using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.EditType
{
    internal class EditTypeCommandHandler : IRequestHandler<EditTypeCommand>
    {
        private readonly IMassageTypeRepository repository;

        public EditTypeCommandHandler(IMassageTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Unit> Handle(EditTypeCommand request, CancellationToken cancellationToken)
        {
            var massageType = await repository.GetTypeByNameAsync(request.Name);
            if(massageType != null)
            {
                massageType.Price = request.Price;
                massageType.Description = request.Description;  
                massageType.Time = request.Time;
                await repository.SaveChangesAsync();
            }
            return Unit.Value;
        }
    }
}
