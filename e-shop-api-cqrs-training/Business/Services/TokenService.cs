using System.Security.Claims;
using Business.Dtos.Auth;
using Business.Interfaces;
using Dal.Entities;
using Dal.Utilities;
using Microsoft.Extensions.Configuration;

namespace Business.Services;

/// <inheritdoc/>
public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the TokenService class.
    /// </summary>
    /// <param name="configuration">The configuration used to generate the access token.</param>
    public TokenService(IConfiguration configuration) { _configuration = configuration; }

    /// <inheritdoc/>
    public SignInResponseDto GenerateAccessToken(AppUser user, IEnumerable<string> role)
    {
        var exp = DateTime.Now.AddMinutes(30);

        string token = new JsonWebTokenBuilder(_configuration.GetValue<string>("Jwt:Secret")!)
            .AddIssuer(_configuration.GetValue<string>("Jwt:ValidIssuer")!)
            .AddAudience(_configuration.GetValue<string>("Jwt:ValidAudience")!)
            .AddClaim(ClaimTypes.NameIdentifier, user.Id)
            .AddClaim(ClaimTypes.Email, user.Email!)
            .AddClaim(ClaimTypes.Role, role)
            .AddClaim("csrfToken", "csrfToken a gerer un peu plus tard")
            .SetExpiration(exp)
            .Build();

        return new SignInResponseDto(token, new DateTimeOffset(exp).ToUnixTimeSeconds());
    }
}
