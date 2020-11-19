using JwtAsymmetricKey.Api.Models;

namespace JwtAsymmetricKey.Api.Services.Interfaces
{
    public interface IUserService
    {
        void ValidateCredentials(UserCredentials userCredentials);
    }
}
