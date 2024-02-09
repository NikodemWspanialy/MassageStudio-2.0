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

namespace MassageStudio.Application.UserActions.Queries.GetMassages
{
    internal class GetMassagesQueryHandler : IRequestHandler<GetMassagesQuery, IEnumerable<MassageToListDto>>
    {
        private readonly IUserContext userContext;
        private readonly IMassageStudioRepository repository;
        private readonly IMapper mapper;

        public GetMassagesQueryHandler(IUserContext userContext, IMassageStudioRepository repository, IMapper mapper)
        {
            this.userContext = userContext;
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MassageToListDto>> Handle(GetMassagesQuery request, CancellationToken cancellationToken)
        {
            var currentuser = await userContext.GetCurrentUserAsync();
            if (currentuser != null)
            {
                var massages = repository.GetMassages(request.Lambda);
                return mapper.Map<IEnumerable<MassageToListDto>>(massages);
            }
            throw new Exception("User doe not have permission to do it");
        }
    }
}
