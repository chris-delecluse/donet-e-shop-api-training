using System.Security.Claims;
using Business.Dtos.Auth;
using Business.Interfaces;
using Dal.Entities;
using Dal.Utilities;
using Microsoft.Extensions.Configuration;

namespace Business.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration) { _configuration = configuration; }

    public TokenDto GenerateAccessToken(AppUser user, IEnumerable<string> role)
    {
        string token = new JsonWebTokenBuilder(_configuration.GetValue<string>("Jwt:Secret")!)
            .AddIssuer(_configuration.GetValue<string>("Jwt:ValidIssuer")!)
            .AddAudience(_configuration.GetValue<string>("Jwt:ValidAudience")!)
            .AddClaim(ClaimTypes.NameIdentifier, user.Id)
            .AddClaim(ClaimTypes.Email, user.Email!)
            .AddClaim(ClaimTypes.Role, role)
            .AddClaim("csrfToken", "csrfToken a gerer un peu plus tard")
            .SetExpiration(DateTime.Now.AddMinutes(30))
            .Build();

        return new TokenDto(token,
            DateTime.Now.AddMinutes(30)
                .Millisecond
        );
    }
}
