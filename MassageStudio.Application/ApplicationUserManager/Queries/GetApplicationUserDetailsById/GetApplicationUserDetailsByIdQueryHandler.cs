using AutoMapper;
using MassageStudio.Application.ApplicationUser.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.ApplicationUser.Queries.GetApplicationUserDetails
{
    internal class GetApplicationUserDetailsByIdQueryHandler : IRequestHandler<GetApplicationUserDetailsByIdQuery, ApplicationUserDetailsDto>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserContext userContext;

        public GetApplicationUserDetailsByIdQueryHandler(UserManager<Domain.Entities.ApplicationUser> userManager, IMapper mapper, IUserContext userContext)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userContext = userContext;
        }
        public async Task<ApplicationUserDetailsDto> Handle(GetApplicationUserDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var CurrentUser = await userContext.GetCurrentUserAsync();
            if (CurrentUser != null && CurrentUser.IsInRole("Admin"))
            {
                var user = await userManager.FindByIdAsync(request.Id);
                if(user != null)
                {
                    var userDetailsDto = mapper.Map<ApplicationUserDetailsDto>(user);

                    //TODO przeniesc do mappera
                    userDetailsDto.Roles = await userManager.GetRolesAsync(user);
                    return userDetailsDto;
                }
            }
            return new ApplicationUserDetailsDto();
        }
    }
}
