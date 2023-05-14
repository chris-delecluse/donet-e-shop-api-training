using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Web_api.Extensions;

/// <summary>
/// A static class responsible for registering authentication services with the service collection.
/// </summary>
public static class AuthenticationServiceExtension
{
    /// <summary>
    /// Registers JWT authentication services with the service collection.
    /// </summary>
    /// <param name="service">The service collection to register the authentication services with.</param>
    /// <param name="configuration">The configuration instance containing JWT settings.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection RegisterAuthenticationService(
        this IServiceCollection service,
        IConfiguration configuration
    )
    {
        service.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
            .AddJwtBearer(opt =>
                {
                    opt.SaveToken = true;
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = configuration.GetValue<string>("JWT:ValidAudience"),
                        ValidIssuer = configuration.GetValue<string>("JWT:ValidIssuer"),
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetValue<string>("JWT:Secret")!)
                            )
                    };
                }
            );

        return service;
    }
}
