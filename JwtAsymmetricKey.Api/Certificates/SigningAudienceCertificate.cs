using JwtAsymmetricKey.Api.Certificates.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using System.Security.Cryptography;

namespace JwtAsymmetricKey.Api.Certificates
{
    public class SigningAudienceCertificate : ISigningAudienceCertificate
    {
        private readonly RSA rsa;

        public SigningAudienceCertificate()
        {
            rsa = RSA.Create();
        }

        public SigningCredentials GetAudienceSigningKey()
        {
            string privateXmlKey = File.ReadAllText("./private_key.xml");
            rsa.FromXmlString(privateXmlKey);

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }

        public void Dispose()
        {
            rsa?.Dispose();
        }
    }
}
