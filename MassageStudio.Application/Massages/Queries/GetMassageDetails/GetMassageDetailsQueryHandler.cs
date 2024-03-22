using AutoMapper;
using MassageStudio.Application.ApplicationUser;
using MassageStudio.Application.Massages.Dtos;
using MassageStudio.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Massages.Queries.GetMassageDetails
{
    internal class GetMassageDetailsQueryHandler : IRequestHandler<GetMassageDetailsQuery, MassageDetailsDto>
    {
        private readonly IMassageTermRepository repository;
        private readonly IMapper mapper;

        public GetMassageDetailsQueryHandler(IMassageTermRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<MassageDetailsDto> Handle(GetMassageDetailsQuery request, CancellationToken cancellationToken)
        {
            
                var massage = await repository.GetMassageByIsAsync(request.Id);
                if (massage != null)
                    return mapper.Map<MassageDetailsDto>(massage);
                else
                    throw new Exception($"Cant find massage with id {request.Id}");
            
        }
    }
}
