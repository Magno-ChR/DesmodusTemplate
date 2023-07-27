using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesmodusTemplate.LogicServices
{
    public class UsuarioLS
    {
        private readonly HomeContext context;
        private readonly IMapper mapper;

        public UsuarioLS(HomeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ObjectResult> GetListLoginUsuarios()
        {
            var data = await context.Usuario.ToListAsync();
            if (data == null)
                Responses.Error404();
            return Responses.Get(mapper.Map<List<UsuarioLoginDto>>(data));
        }
    }
}
