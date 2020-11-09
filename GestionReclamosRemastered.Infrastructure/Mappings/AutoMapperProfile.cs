using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;

namespace GestionReclamosRemastered.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UserDto>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserDto, Usuario>();

            CreateMap<Representante, RepresentativeDto>();
            CreateMap<RepresentativeDto, Representante>();
            CreateMap<ReclamanteDto, Reclamante>();
            CreateMap<Reclamante, ReclamanteDto>();
        }
    }
}
