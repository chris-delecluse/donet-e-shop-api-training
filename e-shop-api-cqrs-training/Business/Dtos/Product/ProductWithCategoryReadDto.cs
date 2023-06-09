using Business.Dtos.Category;

namespace Business.Dtos.Product;

public class ProductWithCategoryReadDto: BaseProductDto
{
    public Guid Id { get; init; }
    public CategoryReadDto Category { get; init; }
}
