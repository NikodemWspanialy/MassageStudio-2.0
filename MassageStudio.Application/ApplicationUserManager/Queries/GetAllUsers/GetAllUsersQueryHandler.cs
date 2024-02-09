using AutoMapper;
using MassageStudio.Application.ApplicationUser.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.GetAllUsers
{
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<ApplicationUserListedDto>>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public GetAllUsersQueryHandler(UserManager<Domain.Entities.ApplicationUser> userManager, IMapper mapper, IUserContext userContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userContext = userContext;
        }
        public async Task<IEnumerable<ApplicationUserListedDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var correntUser = await userContext.GetCurrentUserAsync();
            if (correntUser != null && correntUser.IsInRole("Admin"))
            {
                var users = userManager.Users.ToList();
                var usersDto = mapper.Map<IEnumerable<ApplicationUserListedDto>>(users);
                return usersDto;
            }
            throw new NotImplementedException();
        }
    }
}
