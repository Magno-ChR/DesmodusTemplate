using AutoMapper;
using DesmodusTemplate.DTOs.Persona;
using DesmodusTemplate.Entities.Autores;

namespace DesmodusTemplate.LogicServices
{
    public class PersonaLS
    {
        private readonly IMapper mapper;

        public PersonaLS(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<DTO_Persona> GetListPersonas()
        {
            List<Persona> data = new List<Persona>();
            data.Add(new Persona 
            {
                IdPersona = 1,
                Nombre = "Juan",
                PrimerApellido = "Ximenez",
                SegundoApellido = "Guardiola",
                NroDocumento = "55141627",
                FechaNacimiento = DateTime.Now,
                IdPais = 1,
                Estado = true
            });
            data.Add(new Persona { IdPersona = 1, Nombre = "Ximena", PrimerApellido = "Juanes", SegundoApellido = "Quispe", NroDocumento = "12345667", FechaNacimiento = DateTime.Now, IdPais = 2, Estado = true});

            return mapper.Map<List<DTO_Persona>>(data);
        }
    }
}
