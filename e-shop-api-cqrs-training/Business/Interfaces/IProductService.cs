using Business.Dtos.Product;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface representing the service for managing products.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Creates a new product using the provided data in ProductCreateDto.
        /// </summary>
        /// <param name="dto">The ProductCreateDto object containing the product data.</param>
        /// <returns>The corresponding ProductReadDto object for the created product.</returns>
        Task<ProductReadDto> Create(ProductCreateDto dto);

        /// <summary>
        /// Retrieves all existing products.
        /// </summary>
        /// <returns>A collection of ProductReadDto objects representing all products.</returns>
        Task<IEnumerable<ProductReadDto>> GetAll();

        /// <summary>
        /// Retrieves a specific product using the unique identifier guid.
        /// </summary>
        /// <param name="guid">The unique identifier of the product.</param>
        /// <returns>The corresponding ProductReadDto object for the found product, or null if not found.</returns>
        Task<ProductReadDto?> GetOne(Guid guid);

        /// <summary>
        /// Retrieves a specific product using the unique identifier guid and includes the details of the associated category.
        /// </summary>
        /// <param name="guid">The unique identifier of the product.</param>
        /// <returns>The corresponding ProductDetailReadDto object for the found product, including the category details, or null if not found.</returns>
        Task<ProductDetailReadDto?> GetOneIncludeCategory(Guid guid);
    }
}
