using Dal.Entities;

namespace Dal.Interfaces;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAllAsync();
}
