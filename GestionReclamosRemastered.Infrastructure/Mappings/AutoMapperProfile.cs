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
            CreateMap<TipoUsuario, TipoUsuarioDto>();
            CreateMap<TipoUsuarioDto, TipoUsuario>();

            //Monto
            CreateMap<Monto, MontoDto>();
            CreateMap<MontoDto, Monto>();

            //ConceptoPago
            CreateMap<ConceptoPago, ConceptoPagoDto>();
            CreateMap<ConceptoPagoDto, ConceptoPago>();
        }
    }
}
