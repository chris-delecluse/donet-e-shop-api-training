using Dal.Entities;

namespace Dal.Interfaces;

/// <summary>
/// Interface for the category repository.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Adds a category asynchronously.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <returns>The added category.</returns>
    Task<Category> AddAsync(Category category);

    /// <summary>
    /// Adds a category asynchronously with a cancellation token.
    /// </summary>
    /// <param name="category">The category to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The added category.</returns>
    Task<Category> AddAsync(Category category, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all categories asynchronously.
    /// </summary>
    /// <returns>A collection of categories.</returns>
    Task<IEnumerable<Category>> FindAsync();

    /// <summary>
    /// Retrieves all categories asynchronously with a cancellation token.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of categories.</returns>
    Task<IEnumerable<Category>> FindAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a category by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <returns>The corresponding category, or null if it doesn't exist.</returns>
    Task<Category?> FindAsync(Guid id);

    /// <summary>
    /// Retrieves a category by its ID asynchronously with a cancellation token.
    /// </summary>
    /// <param name="id">The ID of the category.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The corresponding category, or null if it doesn't exist.</returns>
    Task<Category?> FindAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a category by its name asynchronously.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    /// <returns>The corresponding category, or null if it doesn't exist.</returns>
    Task<Category?> FindAsync(string name);

    /// <summary>
    /// Retrieves a category by its name asynchronously with a cancellation token.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The corresponding category, or null if it doesn't exist.</returns>
    Task<Category?> FindAsync(string name, CancellationToken cancellationToken);
}
