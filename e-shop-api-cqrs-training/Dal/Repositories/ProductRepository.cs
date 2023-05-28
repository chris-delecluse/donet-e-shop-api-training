using Dal.Database.Access;
using Dal.Entities;
using Dal.Filters;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

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

    public async Task<IEnumerable<Product>> FindAsync(ProductListQueryFilter filter)
    {
        IQueryable<Product>? query = _dbContext.Products.Where(x => filter.IsDeleted == null || x.IsDeleted == filter.IsDeleted);
        
        query = filter.SortByDescending is not null && filter.SortByDescending is true ? 
            query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Product>> FindAsync(
        ProductListQueryFilter filter,
        CancellationToken cancellationToken
    )
    {
        IQueryable<Product>? query = _dbContext.Products.Where(x => filter.IsDeleted == null || x.IsDeleted == filter.IsDeleted);
        
        query = filter.SortByDescending is not null && filter.SortByDescending is true ? 
            query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<Product?> FindAsync(Guid id)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Product?> FindAndIncludeFulLDetailAsync(Guid id)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(c => c.Category)
            .Include(s => s.ProductStock)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> FindAndIncludeFulLDetailAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(c => c.Category)
            .Include(s => s.ProductStock)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Product?> FindAndIncludeCategoryAsync(Guid id)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(c => c.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> FindAndIncludeCategoryAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(c => c.Category)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Product?> FindAndIncludeStockAsync(Guid id)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(s => s.ProductStock)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Product?> FindAndIncludeStockAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Products.Where(x => x.IsDeleted == false)
            .Include(s => s.ProductStock)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        _dbContext.Products.Update(product);
        int result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _dbContext.Products.Update(product);
        int result = await _dbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}
