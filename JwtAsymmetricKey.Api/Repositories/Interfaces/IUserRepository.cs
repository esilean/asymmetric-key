using JwtAsymmetricKey.Api.Models;

namespace JwtAsymmetricKey.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username);
    }
}
