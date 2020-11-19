using JwtAsymmetricKey.Api.Models;

namespace JwtAsymmetricKey.Api.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string Authenticate(UserCredentials userCredentials);
    }
}
