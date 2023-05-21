using Business.Dtos.Product;
using Dal.Entities;

namespace Business.Interfaces;

public interface IProductService
{
    Task<Product> Create(ProductCreateDto productCreateDto);
}
