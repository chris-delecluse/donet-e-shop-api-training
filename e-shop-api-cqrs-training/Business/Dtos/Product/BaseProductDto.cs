namespace Business.Dtos.Product;

public abstract class BaseProductDto
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}
