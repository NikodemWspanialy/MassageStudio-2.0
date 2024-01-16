using AutoMapper;
using MassageStudio.Application.Types.Dtos;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Queries.GetTypeByName
{
    internal class GetTypeByNameQueryHandler : IRequestHandler<GetTypeByNameQuery, MassageTypeDto>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IMapper mapper;

        public GetTypeByNameQueryHandler(IMassageStudioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<MassageTypeDto> Handle(GetTypeByNameQuery request, CancellationToken cancellationToken)
        {
            var massageType = await repository.GetTypeByNameAsync(request.Name);
            return mapper.Map<MassageTypeDto>(massageType);
        }
    }
}
