using DesmodusTemplate.DTOs;
using DesmodusTemplate.LogicServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesmodusTemplate.Controllers
{

    [Route("api/[controller]")]
    [ApiController] //Validaciones automaticas respecto a los datos recividos
    [ProducesResponseType(typeof(Respuesta<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Respuesta<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Respuesta<string>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Respuesta<string>), StatusCodes.Status500InternalServerError)]
    [Authorize]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaLS personaLS;

        public PersonasController(PersonaLS personaLS)
        {
            this.personaLS = personaLS;
        }
        [HttpGet]
        //[AllowAnonymous]
        [ProducesResponseType(typeof(Respuesta<List<PersonaDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PersonaDto>>> GetListPersonas()
        {
            try
            {
                return await personaLS.GetListPersonas();

            }
            catch (Exception ex)
            {
                return Responses.Error500(ex.Message);
            }
        }
        [HttpGet("GetMe")]
        [ProducesResponseType(typeof(Respuesta<PersonaDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PersonaDto>> GetMe()
        {
            try
            {

                return await personaLS.GetMe();

            }
            catch (Exception ex)
            {
                return Responses.Error500(ex.Message);
            }
        }
    }
}
