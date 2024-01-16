using AutoMapper;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Commands.AddType
{
    internal class AddTypeCommandHandler : IRequestHandler<AddTypeCommand>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IMapper mapper;

        public AddTypeCommandHandler(IMassageStudioRepository repository, IMapper mapper) {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(AddTypeCommand request, CancellationToken cancellationToken)
        {
            var newType = mapper.Map<Domain.Entities.Type>(request);
            await repository.AddTypeAsync(newType);
            return Unit.Value;
        }
    }
}
