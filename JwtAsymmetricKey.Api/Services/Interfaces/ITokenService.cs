namespace JwtAsymmetricKey.Api.Services.Interfaces
{
    public interface ITokenService
    {
        string GetToken(string username);
    }
}
