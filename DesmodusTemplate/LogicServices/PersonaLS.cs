using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.LogicServices
{
    public class PersonaLS
    {
        private readonly HomeContext context;
        private readonly IMapper mapper;

        public PersonaLS(HomeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<PersonaDto>> GetListPersonas()
        {
            var data = await context.Persona.ToListAsync();
          
            return mapper.Map<List<PersonaDto>>(data);
        }
    }
}
