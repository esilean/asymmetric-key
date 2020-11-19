using JwtAsymmetricKey.Api.Certificates.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace JwtAsymmetricKey.Api.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAsymmetricAuthentication(this IServiceCollection services)
        {

            // Build the intermediate service provider
            var sp = services.BuildServiceProvider();
            var signingIssuerCertificate = sp.GetService<ISigningIssuerCertificate>();

            RsaSecurityKey issuerSigningKey = signingIssuerCertificate.GetIssuerSigningKey();
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = issuerSigningKey,
                        LifetimeValidator = LifetimeValidator
                    };
                });

            return services;
        }

        private static bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires != null && expires > DateTime.UtcNow;
        }
    }
}
