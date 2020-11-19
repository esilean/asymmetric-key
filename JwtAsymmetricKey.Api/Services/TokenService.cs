using JwtAsymmetricKey.Api.Certificates.Interfaces;
using JwtAsymmetricKey.Api.Models;
using JwtAsymmetricKey.Api.Repositories.Interfaces;
using JwtAsymmetricKey.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JwtAsymmetricKey.Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISigningAudienceCertificate _signingAudienceCertificate;

        public TokenService(ISigningAudienceCertificate signingAudienceCertificate, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _signingAudienceCertificate = signingAudienceCertificate;
        }

        public string GetToken(string username)
        {
            User user = _userRepository.GetUser(username);
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(User user)
        {
            const int expiringDays = 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.Claims()),
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = _signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
