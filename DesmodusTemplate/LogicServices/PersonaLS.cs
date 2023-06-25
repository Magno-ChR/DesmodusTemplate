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
        private readonly IUserService user;

        public PersonaLS(HomeContext context, IMapper mapper, IUserService user)
        {
            this.context = context;
            this.mapper = mapper;
            this.user = user;
        }

        public async Task<List<PersonaDto>> GetListPersonas()
        {
            var data = await context.Persona.ToListAsync();
          
            return mapper.Map<List<PersonaDto>>(data);
        }
        public async Task<PersonaDto> GetMe()
        {
            var claims = user.JWTClaims();
            var data = await context.Persona.FirstOrDefaultAsync(x => x.NroDocumento == claims.Documento);

            return mapper.Map<PersonaDto>(data);

        }
    }
}
