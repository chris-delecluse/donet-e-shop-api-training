using Business.Dtos.Product;
using Dal.Entities;

namespace Business.Interfaces;

public interface IProductService
{
    Task<ProductReadDto> Create(ProductCreateDto dto);
    Task<IEnumerable<ProductReadDto>> GetAll();
    Task<ProductReadDto?> GetOne(Guid guid);
    Task<ProductDetailReadDto?> GetOneWithDetails(Guid guid);
}
