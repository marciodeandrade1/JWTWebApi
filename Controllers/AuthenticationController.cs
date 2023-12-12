using JWTWebApi.Models;
using JWTWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWTWebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpPost]
        [Route("Login")]
        public AuthenticateResponse Login(AuthenticateRequest model)
        {
            return this.authenticationService.Authenticate(model);

        }
    }
}
