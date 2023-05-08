using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Database.Seeds;

internal record SeedUserDataList(AppUser User, string Password);

public static class SeedUserData
{
    private static readonly IEnumerable<SeedUserDataList> _userList = new List<SeedUserDataList>()
    {
        new(new() { FirstName = "admin", LastName = "admin", Email = "admin@gmail.com", UserName = "admin@gmail.com" },
            "Pa$$w0rd"
        )
    };

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
