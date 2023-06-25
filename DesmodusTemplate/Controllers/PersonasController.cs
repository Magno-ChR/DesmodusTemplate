using DesmodusTemplate.DTOs;
using DesmodusTemplate.LogicServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesmodusTemplate.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController] //Validaciones automaticas respecto a los datos recividos
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status403Forbidden)]
    [Authorize]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaLS personaLS;

        public PersonasController(PersonaLS personaLS) {
            this.personaLS = personaLS;
        }
        [HttpGet]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(List<PersonaDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PersonaDto>>> GetListPersonas()
        {
            try
            {
                var data = await personaLS.GetListPersonas();

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
        [HttpGet("GetMe")]
        [ProducesResponseType(typeof(PersonaDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonaDto>> GetMe()
        {
            try
            {
                var data = await  personaLS.GetMe();

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
