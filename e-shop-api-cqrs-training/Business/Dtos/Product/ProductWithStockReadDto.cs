using Business.Dtos.Stock;

namespace Business.Dtos.Product;

public class ProductWithStockReadDto : BaseProductDto
{
    public Guid Id { get; init; }
    public ProductStockReadDto Stock { get; init; } 
}
