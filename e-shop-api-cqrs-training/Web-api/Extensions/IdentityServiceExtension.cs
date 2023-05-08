using Dal.Database.Access;
using Dal.Entities;
using Microsoft.AspNetCore.Identity;

namespace Web_api.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddCustomIdentityConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddIdentity<AppUser, IdentityRole>(opt =>
                {
                    opt.SignIn.RequireConfirmedAccount = false;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequiredLength = 6;
                }
            )
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        return serviceCollection;
    }
}
