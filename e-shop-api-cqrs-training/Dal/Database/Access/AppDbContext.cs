using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dal.Database.Access;

public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration) { _configuration = configuration; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("MySql")!);

        base.OnConfiguring(optionsBuilder);
    }
}
