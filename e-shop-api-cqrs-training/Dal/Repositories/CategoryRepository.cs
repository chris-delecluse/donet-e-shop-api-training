using Dal.Database.Access;
using Dal.Entities;
using Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext) { _dbContext = dbContext; }

    public async Task<Category> AddAsync(Category category)
    {
        EntityEntry<Category> result = await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken)
    {
        EntityEntry<Category> result = await _dbContext.Categories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<IEnumerable<Category>> FindAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<IEnumerable<Category>> FindAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.ToListAsync(cancellationToken);
    }

    public async Task<Category?> FindAsync(Guid id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<Category?> FindAsync(string name)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Category?> FindAsync(string name, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
}
