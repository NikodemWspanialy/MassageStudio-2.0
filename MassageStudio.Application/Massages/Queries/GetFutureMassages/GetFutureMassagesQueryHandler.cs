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

namespace MassageStudio.Application.Massages.Queries.GetFutureMassages
{
    internal class GetFutureMassagesQueryHandler : IRequestHandler<GetFutureMassagesQuery, IEnumerable<MassageToListDto>>
    {
        private readonly IMassageTermRepository repository;
        private readonly IUserContext userContex;
        private readonly IMapper mapper;

        public GetFutureMassagesQueryHandler(IMassageTermRepository repository, IUserContext userContex, IMapper mapper)
        {
            this.repository = repository;
            this.userContex = userContex;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<MassageToListDto>> Handle(GetFutureMassagesQuery request, CancellationToken cancellationToken)
        {
            var currentuser = await userContex.GetCurrentUserAsync();
            if (currentuser != null && currentuser.IsInRole("Masseur"))
            {
                var massageList = await repository.GetAllMassagesAsync(DateTime.Now);
                var massageDtoList = mapper.Map<IEnumerable<MassageToListDto>>(massageList);

                return massageDtoList;
            }
            throw new Exception("User do not have permission to get all massages");
        }
    }
}
