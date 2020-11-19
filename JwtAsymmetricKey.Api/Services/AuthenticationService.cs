using JwtAsymmetricKey.Api.Models;
using JwtAsymmetricKey.Api.Services.Interfaces;

namespace JwtAsymmetricKey.Api.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public string Authenticate(UserCredentials userCredentials)
        {
            _userService.ValidateCredentials(userCredentials);
            string securityToken = _tokenService.GetToken(userCredentials.Username);

            return securityToken;
        }
    }
}
