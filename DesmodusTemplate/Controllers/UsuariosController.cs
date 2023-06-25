using DesmodusTemplate.DTOs;
using DesmodusTemplate.Entities.Artec;
using DesmodusTemplate.LogicServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesmodusTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status403Forbidden)]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioLS usuarioLS;

        public UsuariosController( UsuarioLS usuarioLS)
        {
            this.usuarioLS = usuarioLS;
        }
        [HttpGet]
        [Authorize(Roles = "root")]
        [ProducesResponseType(typeof(List<UsuarioLoginDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UsuarioLoginDto>>> GetListLoginUsuarios()
        {
            try
            {
                var data = await usuarioLS.GetListLoginUsuarios();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
