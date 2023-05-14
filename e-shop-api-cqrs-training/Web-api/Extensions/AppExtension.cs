using Dal.Database.Seeds;

namespace Web_api.Extensions;

public static class AppExtension
{
    /// <summary>
    /// Seeds the database with initial data on application startup.
    /// </summary>
    /// <param name="app">The web application.</param>
    /// <returns>The web application.</returns>
    public static WebApplication SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;

        SeedRoleData.InitializeAsync(serviceProvider)
            .Wait();

        SeedUserData.InitializeAsync(serviceProvider)
            .Wait();

        return app;
    }
}
