using System.Security.Claims;
using Dal.Commands.Role;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Dal.Database.Seeds;

/// <summary>
/// A static class responsible for seeding roles data in the database.
/// </summary>
public static class SeedRoleData
{
    private static readonly string[] RoleNames = new[] { "admin", "manager", "customer" };

    /// <summary>
    /// Initializes roles in the database. If the role doesn't exist, a role is created with a specified name.
    /// Appropriate claims are also added for each role.
    /// </summary>
    /// <param name="serviceProvider">Service provider used to get instances of role and mediator managers.</param>
    /// <returns>An asynchronous task that represents the completion of role initialization.</returns>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        foreach (string role in RoleNames)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var roleCommand = new CreateRoleCommand() { Name = role };
                await mediator.Send(roleCommand);
            }
        }
 
        await AddAdminClaims(roleManager);
        await AddManagerClaims(roleManager);
        await AddCustomerClaims(roleManager);
    }

    private static async Task AddAdminClaims(RoleManager<IdentityRole> roleManager)
    {
        var adminRole = await roleManager.FindByNameAsync("admin");

        var adminClaims = new List<Claim> { new("permission", "manage_users"), new("permission", "manage_roles") };

        foreach (var claim in adminClaims)
        {
            var existingClaim = await roleManager.GetClaimsAsync(adminRole);

            if (!existingClaim.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                await roleManager.AddClaimAsync(adminRole, claim);
        }
    }

    private static async Task AddManagerClaims(RoleManager<IdentityRole> roleManager)
    {
        var managerRole = await roleManager.FindByNameAsync("manager");

        var managerClaims = new List<Claim>
        {
            new("permission", "manage_products"), new("permission", "manage_orders")
        };

        foreach (var claim in managerClaims)
        {
            var existingClaim = await roleManager.GetClaimsAsync(managerRole);

            if (!existingClaim.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                await roleManager.AddClaimAsync(managerRole, claim);
        }
    }

    private static async Task AddCustomerClaims(RoleManager<IdentityRole> roleManager)
    {
        var customerRole = await roleManager.FindByNameAsync("customer");

        var customerClaims = new List<Claim> { new("permission", "view_products"), new("permission", "place_orders") };

        foreach (var claim in customerClaims)
        {
            var existingClaim = await roleManager.GetClaimsAsync(customerRole);

            if (!existingClaim.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                await roleManager.AddClaimAsync(customerRole, claim);
        }
    }
}
