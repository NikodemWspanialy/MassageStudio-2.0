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

namespace MassageStudio.Application.Massages.Queries.GetAllMassages
{
    internal class GetAllMassagesQueryHandler : IRequestHandler<GetAllMassagesQuery, IEnumerable<MassageToListDto>>
    {
        private readonly IMassageStudioRepository repository;
        private readonly IUserContext userContex;
        private readonly IMapper mapper;

        public GetAllMassagesQueryHandler(IMassageStudioRepository repository, IUserContext userContex, IMapper mapper)
        {
            this.repository = repository;
            this.userContex = userContex;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MassageToListDto>> Handle(GetAllMassagesQuery request, CancellationToken cancellationToken)
        {
            var currentuser = await userContex.GetCurrentUserAsync();
            if (currentuser != null && currentuser.IsInRole("Masseur"))
            {
                var massageList = await repository.GetAllMassagesAsync();
                var massageDtoList = mapper.Map<IEnumerable<MassageToListDto>>(massageList);
                
                return massageDtoList;
            }
            throw new Exception("User do not have permission to get all massages");
        }
    }
}
