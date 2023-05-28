using Dal.Entities;
using Dal.Filters;

namespace Dal.Interfaces;

/// <summary>
/// Interface for the product repository.
/// </summary>
public interface IProductRepository
{
    #region Add a product.

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

    #endregion

    # region Find a product (basic and include some category).

    /// <summary>
    /// Retrieves a list of products from the repository based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter to apply.</param>
    /// <returns>The list of found products.</returns>
    Task<IEnumerable<Product>> FindAsync(ProductListQueryFilter filter);

    /// <summary>
    /// Retrieves a list of products from the repository based on the specified filter and cancellation token.
    /// </summary>
    /// <param name="filter">The filter to apply.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of found products.</returns>
    Task<IEnumerable<Product>> FindAsync(ProductListQueryFilter filter, CancellationToken cancellationToken);

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
    /// Retrieves a product by its ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The found product with all details, or null if not found.</returns>
    Task<Product?> FindAndIncludeFulLDetailAsync(Guid id);

    /// <summary>
    /// Retrieves a product by its ID from the repository with a cancellation token.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found product with all details, or null if not found.</returns>
    Task<Product?> FindAndIncludeFulLDetailAsync(Guid id, CancellationToken cancellationToken);

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

    /// <summary>
    /// Retrieves a product and stock by product ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <returns>The found product with stock, or null if not found.</returns>
    Task<Product?> FindAndIncludeStockAsync(Guid id);

    /// <summary>
    /// Retrieves a product and stock by product ID from the repository with a cancellation token.
    /// </summary>
    /// <param name="id">The ID of the product.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found product with stock, or null if not found.</returns>
    Task<Product?> FindAndIncludeStockAsync(Guid id, CancellationToken cancellationToken);

    #endregion

    # region Update a product.

    /// <summary>
    /// Updates a product in the repository.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <returns>True if the update is successful, false otherwise.</returns>
    Task<bool> UpdateProductAsync(Product product);

    /// <summary>
    /// Updates a product in the repository with a cancellation token.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>True if the update is successful, false otherwise.</returns>
    Task<bool> UpdateProductAsync(Product product, CancellationToken cancellationToken);

    #endregion
}
