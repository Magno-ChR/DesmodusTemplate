using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DesmodusTemplate.DTOs;
using System.Text;
using System.Security.Cryptography;
using DesmodusTemplate.Entities.Artec;
using DesmodusTemplate.LogicServices;

namespace DesmodusTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IActionResult), StatusCodes.Status500InternalServerError)]
    public class AuthController : ControllerBase
    {
        private readonly AuthLS authLS;

        public AuthController(AuthLS authLS)
        {
            this.authLS = authLS;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UsuarioEditDto data)
        {
            try
            {
                return await authLS.register(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UsuarioLoginDto data)
        {
            try
            {
                return await authLS.login(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

    }
}
