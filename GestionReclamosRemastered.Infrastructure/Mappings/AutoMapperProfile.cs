using AutoMapper;
using GestionReclamosRemastered.Core.DTOs;
using GestionReclamosRemastered.Core.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

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
            CreateMap<TipoUsuario, TipoUsuarioDto>().ReverseMap();
            // Reclamante
            CreateMap<ReclamanteDto, Reclamante>().ReverseMap();            
            // Siniestro
            CreateMap<Siniestro, SiniestroDto>().ReverseMap();
            CreateMap<JsonPatchDocument<Siniestro>, JsonPatchDocument<SiniestroDto>>().ReverseMap();
            CreateMap<Operation<SiniestroDto>, Operation<Siniestro>>();
        }
    }
}
