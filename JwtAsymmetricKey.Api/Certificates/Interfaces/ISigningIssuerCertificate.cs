using Microsoft.IdentityModel.Tokens;
using System;

namespace JwtAsymmetricKey.Api.Certificates.Interfaces
{
    public interface ISigningIssuerCertificate : IDisposable
    {
        RsaSecurityKey GetIssuerSigningKey();
    }
}
