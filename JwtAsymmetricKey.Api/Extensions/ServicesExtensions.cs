using JwtAsymmetricKey.Api.Certificates;
using JwtAsymmetricKey.Api.Certificates.Interfaces;
using JwtAsymmetricKey.Api.Repositories;
using JwtAsymmetricKey.Api.Repositories.Interfaces;
using JwtAsymmetricKey.Api.Services;
using JwtAsymmetricKey.Api.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace JwtAsymmetricKey.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISigningAudienceCertificate, SigningAudienceCertificate>();
            services.AddTransient<ISigningIssuerCertificate, SigningIssuerCertificate>();

            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

    }
}
