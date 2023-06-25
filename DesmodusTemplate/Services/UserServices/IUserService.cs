using DesmodusTemplate.DTOs;

namespace DesmodusTemplate.Services.UserServices
{
    public interface IUserService
    {
        UserJWTClaims JWTClaims();
    }
}
