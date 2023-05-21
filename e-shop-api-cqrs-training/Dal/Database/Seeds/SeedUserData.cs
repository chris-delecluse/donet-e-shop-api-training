using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Database.Seeds;

/// <summary>
/// A static class responsible for seeding user data in the database.
/// </summary>
internal record SeedUserDataList(AppUser User, string Password);

public static class SeedUserData
{
    private static readonly IEnumerable<SeedUserDataList> _userList = new List<SeedUserDataList>()
    {
        new(new() { FirstName = "admin", LastName = "admin", Email = "admin@gmail.com", UserName = "admin@gmail.com" },
            "@Dmin1"
        )
    };

    /// <summary>
    /// Initializes the user data in the database by creating a user and adding them to the "admin" role if they don't already exist.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to get instances of the user manager.</param>
    /// <returns>An asynchronous task that represents the completion of the user data initialization.</returns>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        foreach (SeedUserDataList item in _userList)
        {
            var existingUser = await userManager.FindByEmailAsync(item.User.Email);
            if (existingUser is null)
            {
                await userManager.CreateAsync(item.User, item.Password);
                await userManager.AddToRoleAsync(item.User, "admin");
            }
        }
    }
}
