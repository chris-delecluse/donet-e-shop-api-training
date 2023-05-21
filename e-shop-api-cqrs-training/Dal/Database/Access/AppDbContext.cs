using Dal.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dal.Database.Access;

/// <summary>
/// DbContext for the application's data access layer, based on Entity Framework Core and Identity.
/// </summary>
public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
{
    private readonly IConfiguration _configuration;

    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories { get; set; }
    // public DbSet<ProductImage> Images { get; set; }
    // public DbSet<Review> Reviews { get; set; }
    // public DbSet<Stock> Stocks { get; set; }
    // public DbSet<Order> Orders { get; set; }
    // public DbSet<OrderItem> Items { get; set; }
    // public DbSet<OrderStatus> Status { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class with the specified configuration.
    /// </summary>
    /// <param name="configuration">The configuration to use for the context.</param>
    public AppDbContext(IConfiguration configuration) { _configuration = configuration; }

    /// <summary>
    /// Configures the context with the specified options.
    /// </summary>
    /// <param name="optionsBuilder">The options builder to configure.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_configuration.GetConnectionString("MySql")!);

        base.OnConfiguring(optionsBuilder);
    }
}
