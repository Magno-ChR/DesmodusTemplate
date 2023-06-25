using AutoMapper;
using DesmodusTemplate.DTOs;
using DesmodusTemplate.Entities.Artec;

namespace DesmodusTemplate.Config
{
    public class AutoMapperMaps : Profile
    {
        public AutoMapperMaps() {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Usuario, UsuarioLoginDto>();
            CreateMap<UsuarioEditDto, Usuario>();
        }
    }
}
