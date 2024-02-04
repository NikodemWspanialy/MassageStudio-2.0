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
        private readonly IMassageStudioRepository repository;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public GetMassageDetailsQueryHandler(IMassageStudioRepository repository, IMapper mapper, IUserContext userContext)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.userContext = userContext;
        }
        public async Task<MassageDetailsDto> Handle(GetMassageDetailsQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userContext.GetCurrentUserAsync();
            if (currentUser != null && currentUser.IsInRole("Masseur"))
            {
                var massage = await repository.GetMassageByIsAsync(request.Id);
                if (massage != null)
                    return mapper.Map<MassageDetailsDto>(massage);
                else
                    throw new Exception($"Cant find massage with id {request.Id}");
            }
            throw new Exception("User do not have permission to get massage details");
        }
    }
}
