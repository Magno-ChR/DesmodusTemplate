using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs.Persona;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.LogicServices
{
    public class PersonaLS
    {
        private readonly ArtecContext context;
        private readonly IMapper mapper;

        public PersonaLS(ArtecContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DTO_Persona>> GetListPersonas()
        {
            var data = await context.Personas.ToListAsync();
            //List<Persona> data = new List<Persona>();
            //data.Add(new Persona 
            //{
            //    IdPersona = 1,
            //    Nombre = "Juan",
            //    PrimerApellido = "Ximenez",
            //    SegundoApellido = "Guardiola",
            //    NroDocumento = "55141627",
            //    FechaNacimiento = DateTime.Now,
            //    IdPais = 1,
            //    Estado = true
            //});
            //data.Add(new Persona { IdPersona = 1, Nombre = "Ximena", PrimerApellido = "Juanes", SegundoApellido = "Quispe", NroDocumento = "12345667", FechaNacimiento = DateTime.Now, IdPais = 2, Estado = true});

            return mapper.Map<List<DTO_Persona>>(data);
        }
    }
}
