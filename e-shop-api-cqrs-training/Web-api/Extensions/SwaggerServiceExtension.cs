using Microsoft.OpenApi.Models;

namespace Web_api.Extensions;

public static class SwaggerServiceExtension
{
    public static IServiceCollection AddSwaggerGenConfigured(this IServiceCollection service)
    {
        service.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "e-shop api", Version = "v1" });
                option.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Enter a valid json web token (JWT)",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    }
                );
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                            },
                            new string[] { }
                        }
                    }
                );
            }
        );
        return service;
    }
}
