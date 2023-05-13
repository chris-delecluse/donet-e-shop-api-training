namespace Dal.Interfaces;

public interface IJsonWebTokenBuilder
{
    IJsonWebTokenBuilder AddIssuer(string issuer);
    IJsonWebTokenBuilder AddAudience(string audience);
    IJsonWebTokenBuilder AddClaim(string type, string value);
    IJsonWebTokenBuilder SetExpiration(DateTime expiration);
    string Build();
}
