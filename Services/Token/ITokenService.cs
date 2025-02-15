namespace MongoDBCars.Services.Token
{
    public interface ITokenService
    {
        string GenerateToken(string Key, string issuer, string audience);
    }
}
