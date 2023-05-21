using Dal.Database.Access;
using Dal.Entities;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) { _dbContext = dbContext; }

    public async Task<Product> AddAsync(Product product)
    {
        EntityEntry<Product> result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken)
    {
        EntityEntry<Product> result = await _dbContext.Products.AddAsync(product, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<IEnumerable<Product>> FindAsync() => await _dbContext.Products.ToListAsync();
    
    public Task<IEnumerable<Product>> FindAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
    public Task<Product?> FindAsync(Guid id) => throw new NotImplementedException();
    public Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken) => throw new NotImplementedException();
}
