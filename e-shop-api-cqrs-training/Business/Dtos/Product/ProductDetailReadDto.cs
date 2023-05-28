using Business.Dtos.Category;
using Business.Dtos.Stock;

namespace Business.Dtos.Product;

public class ProductDetailReadDto: BaseProductDto
{
    public Guid Id { get; init; }
    public CategoryReadDto Category { get; init; }
    public StockReadDto Stock { get; init; }
}
