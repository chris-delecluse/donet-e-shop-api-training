using Business.Dtos.Category;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface representing the service for managing categories.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Creates a new category using the provided data in CategoryCreateDto.
        /// </summary>
        /// <param name="dto">The CategoryCreateDto object containing the category data.</param>
        /// <returns>The corresponding CategoryReadDto object for the created category.</returns>
        Task<CategoryReadDto> Create(CategoryCreateDto dto);

        /// <summary>
        /// Retrieves all existing categories.
        /// </summary>
        /// <returns>A collection of CategoryReadDto objects representing all categories.</returns>
        Task<IEnumerable<CategoryReadDto>> GetAll();

        /// <summary>
        /// Retrieves a specific category using the unique identifier guid.
        /// </summary>
        /// <param name="guid">The unique identifier of the category.</param>
        /// <returns>The corresponding CategoryReadDto object for the found category.</returns>
        Task<CategoryReadDto> GetOne(Guid guid);

        /// <summary>
        /// Retrieves a specific category using the name.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <returns>The corresponding CategoryReadDto object for the found category.</returns>
        Task<CategoryReadDto> GetOne(string name);
    }
}
