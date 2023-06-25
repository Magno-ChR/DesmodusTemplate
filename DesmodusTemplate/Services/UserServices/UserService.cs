using DesmodusTemplate.DTOs;
using System.Security.Claims;

namespace DesmodusTemplate.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private UserJWTClaims UserClaims { get; set; } = new();

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public UserJWTClaims JWTClaims()
        {      
            if(httpContextAccessor.HttpContext != null)
            {
                UserClaims.ID = httpContextAccessor.HttpContext.User.FindFirstValue("ID");
                UserClaims.Documento = httpContextAccessor.HttpContext.User.FindFirstValue("Documento");
                UserClaims.Nombre = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                UserClaims.Genero = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Gender);
                UserClaims.Email = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
                UserClaims.IdRol = httpContextAccessor.HttpContext.User.FindFirstValue("IdRol");
                UserClaims.Rol = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            }
            return UserClaims;
        }
    }
}
