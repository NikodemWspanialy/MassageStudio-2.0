using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.DeleteType
{
    internal class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
    {
        private readonly IMassageStudioRepository repository;

        public DeleteTypeCommandHandler(IMassageStudioRepository repository)
        {
            this.repository = repository;
        }
        public Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            repository.DeleteType(request.Name);
            return Unit.Task;
        }

        
    }
}
