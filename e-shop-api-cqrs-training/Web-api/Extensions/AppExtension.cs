using Dal.Database.Seeds;

namespace Web_api.Extensions;

public static class AppExtension
{
    public static WebApplication SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        SeedRoleData.InitializeAsync(serviceProvider)
            .Wait();

        return app;
    }
}
