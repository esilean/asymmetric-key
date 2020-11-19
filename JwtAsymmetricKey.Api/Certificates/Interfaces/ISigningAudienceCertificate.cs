using Microsoft.IdentityModel.Tokens;
using System;

namespace JwtAsymmetricKey.Api.Certificates.Interfaces
{
    public interface ISigningAudienceCertificate : IDisposable
    {
        SigningCredentials GetAudienceSigningKey();
    }
}
