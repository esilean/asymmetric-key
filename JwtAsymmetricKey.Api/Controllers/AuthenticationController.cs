using JwtAsymmetricKey.Api.Models;
using JwtAsymmetricKey.Api.Models.Exceptions;
using JwtAsymmetricKey.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAsymmetricKey.Api.Controllers
{
    [Route("identity/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            try
            {
                string token = _authenticationService.Authenticate(userCredentials);
                return Ok(token);
            }
            catch (InvalidCredentialsException)
            {
                return Unauthorized();
            }
        }
    }
}
