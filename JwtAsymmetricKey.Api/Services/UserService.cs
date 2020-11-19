using JwtAsymmetricKey.Api.Models;
using JwtAsymmetricKey.Api.Models.Exceptions;
using JwtAsymmetricKey.Api.Repositories.Interfaces;
using JwtAsymmetricKey.Api.Services.Interfaces;

namespace JwtAsymmetricKey.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = _userRepository.GetUser(userCredentials.Username);
            bool isValid = user != null && AreValidCredentials(userCredentials, user);

            if (!isValid)
            {
                throw new InvalidCredentialsException();
            }
        }

        private static bool AreValidCredentials(UserCredentials userCredentials, User user)
        {
            return user.Username == userCredentials.Username &&
                   user.Password == userCredentials.Password;
        }
    }
}
