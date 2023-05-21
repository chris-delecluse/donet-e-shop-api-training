using Dal.Database.Access;
using Dal.Interfaces;

namespace Dal.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;

    public CategoryRepository(AppDbContext dbContext) { _dbContext = dbContext; }
}
