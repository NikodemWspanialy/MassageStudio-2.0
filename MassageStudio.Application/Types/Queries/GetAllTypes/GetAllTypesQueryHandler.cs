using AutoMapper;
using MassageStudio.Application.Types.Dtos;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Types.Queries.GetAllTypes
{
    internal class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<MassageTypeDto>>
    {
        private readonly IMassageTypeRepository repository;
        private readonly IMapper mapper;

        public GetAllTypesQueryHandler(IMassageTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MassageTypeDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var MassageTypes = await repository.GetAllTypesAsync();
            return mapper.Map<IEnumerable<MassageTypeDto>>(MassageTypes);
        }
    }
}
