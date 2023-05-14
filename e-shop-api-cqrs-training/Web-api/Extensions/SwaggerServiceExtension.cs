using Microsoft.OpenApi.Models;

namespace Web_api.Extensions;

public static class SwaggerServiceExtension
{
    /// <summary>
    /// Registers the Swagger generator and configures it for the API.
    /// </summary>
    /// <param name="service">The IServiceCollection instance to register the Swagger generator with.</param>
    /// <returns>The IServiceCollection instance with the Swagger generator registered and configured.</returns>
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
