using AutoMapper;
using DesmodusTemplate.Data;
using DesmodusTemplate.DTOs;
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
        public async Task<List<UsuarioLoginDto>> GetListLoginUsuarios()
        {
            var data = await context.Usuario.ToListAsync();

            return mapper.Map<List<UsuarioLoginDto>>(data);
        }
    }
}
