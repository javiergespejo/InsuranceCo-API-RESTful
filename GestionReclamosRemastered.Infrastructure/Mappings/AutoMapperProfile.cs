using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;

namespace GestionReclamosRemastered.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Usuario
            CreateMap<Usuario, UserDto>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserDto, Usuario>();
            // Tipo de usuario
            CreateMap<TipoUsuario, TipoUsuarioDto>();
            CreateMap<TipoUsuarioDto, TipoUsuario>();
            // Reclamante
            CreateMap<ReclamanteDto, Reclamante>();
            CreateMap<Reclamante, ReclamanteDto>();
            // Siniestro
            CreateMap<Siniestro, SiniestroDto>();
            CreateMap<SiniestroDto, Siniestro>();
        }
    }
}
