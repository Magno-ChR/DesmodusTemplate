using AutoMapper;
using DesmodusTemplate.DTOs.Persona;
using DesmodusTemplate.Entities.Artec;

namespace DesmodusTemplate.Config
{
    public class AutoMapperMaps : Profile
    {
        public AutoMapperMaps() {
            CreateMap<Persona, DTO_Persona>();
            CreateMap<DTO_Persona, Persona>();
        }
    }
}
