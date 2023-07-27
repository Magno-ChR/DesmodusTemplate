using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ObjectResult> GetListPersonas()
        {
            var data = await context.Persona.ToListAsync();
            if (data == null)
                return Responses.Error404();
          
            return Responses.Get(mapper.Map<List<PersonaDto>>(data));
        }
        public async Task<ObjectResult> GetMe()
        {
            var claims = user.JWTClaims();
            var data = await context.Persona.FirstOrDefaultAsync(x => x.NroDocumento == claims.Documento);
            if (data == null)
                return Responses.Error404();

            return Responses.Get(mapper.Map<PersonaDto>(data));

        }
    }
}
