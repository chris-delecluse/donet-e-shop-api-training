using Dal.Entities;

namespace Dal.Interfaces;

/// <summary>
/// Interface for the product repository.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Adds a new product to the repository.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <returns>The added product.</returns>
    Task<Product> AddAsync(Product product);

    /// <summary>
    /// Adds a new product to the repository with a cancellation token.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The added product.</returns>
    Task<Product> AddAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all products from the repository.
    /// </summary>
    /// <returns>A collection of products.</returns>
    Task<IEnumerable<Product>> FindAsync();

    /// <summary>
    /// Retrieves all products from the repository with a cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of products.</returns>
    Task<IEnumerable<Product>> FindAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a product by its ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The found product, or null if not found.</returns>
    Task<Product?> FindAsync(Guid id);

    /// <summary>
    /// Retrieves a product by its ID from the repository with a cancellation token.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found product, or null if not found.</returns>
    Task<Product?> FindAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a product and category by product ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The found product with category, or null if not found</returns>
    Task<Product?> FindAndIncludeCategoryAsync(Guid id);
    
    /// <summary>
    /// Retrieves a product and category by product ID from the repository with a cancellation token.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found product with category, or null if not found.</returns>
    Task<Product?> FindAndIncludeCategoryAsync(Guid id, CancellationToken cancellationToken);
}
