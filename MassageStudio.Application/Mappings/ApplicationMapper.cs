using AutoMapper;
using MassageStudio.Application.ApplicationUser.Dtos;
using MassageStudio.Application.Types.Commands.AddType;
using MassageStudio.Application.Types.Commands.EditType;
using MassageStudio.Application.Types.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassageStudio.Application.Mappings
{
    internal class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<AddTypeCommand, Domain.Entities.Type>();

            CreateMap<Domain.Entities.Type, MassageTypeDto>();

            CreateMap<MassageTypeDto, EditTypeCommand>();

            CreateMap<Domain.Entities.ApplicationUser, ApplicationUserListedDto>()
                .ForMember(e => e.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(e => e.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(e => e.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Domain.Entities.ApplicationUser, ApplicationUserDetailsDto>();
        }
    }
}
