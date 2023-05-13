using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Web_api.Extensions;

public static class AuthenticationServiceExtension
{
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
