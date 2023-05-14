namespace Dal.Interfaces;

/// <summary>
/// Represents a builder for creating JSON Web Tokens (JWTs).
/// </summary>
public interface IJsonWebTokenBuilder
{
    /// <summary>
    /// Adds an issuer to the JWT.
    /// </summary>
    /// <param name="issuer">The issuer of the JWT.</param>
    /// <returns>The <see cref="IJsonWebTokenBuilder"/> instance.</returns>
    IJsonWebTokenBuilder AddIssuer(string issuer);

    /// <summary>
    /// Adds an audience to the JWT.
    /// </summary>
    /// <param name="audience">The audience of the JWT.</param>
    /// <returns>The <see cref="IJsonWebTokenBuilder"/> instance.</returns>
    IJsonWebTokenBuilder AddAudience(string audience);

    /// <summary>
    /// Adds a claim to the JWT.
    /// </summary>
    /// <param name="type">The type of the claim.</param>
    /// <param name="value">The value of the claim.</param>
    /// <returns>The <see cref="IJsonWebTokenBuilder"/> instance.</returns>
    IJsonWebTokenBuilder AddClaim(string type, string value);

    /// <summary>
    /// Adds a claim with multiple values to the JWT.
    /// </summary>
    /// <param name="type">The type of the claim.</param>
    /// <param name="value">The values of the claim.</param>
    /// <returns>The <see cref="IJsonWebTokenBuilder"/> instance.</returns>
    IJsonWebTokenBuilder AddClaim(string type, IEnumerable<string> value);

    /// <summary>
    /// Sets the expiration time of the JWT.
    /// </summary>
    /// <param name="expiration">The expiration time of the JWT.</param>
    /// <returns>The <see cref="IJsonWebTokenBuilder"/> instance.</returns>
    IJsonWebTokenBuilder SetExpiration(DateTime expiration);

    /// <summary>
    /// Builds the JWT.
    /// </summary>
    /// <returns>The JWT as a string.</returns>
    string Build();
}
