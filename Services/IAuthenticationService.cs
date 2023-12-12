using JWTWebApi.Models;

namespace JWTWebApi.Services
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}