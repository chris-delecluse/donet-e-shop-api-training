namespace Business.Dtos.Product;

public class ProductReadDto: BaseProductDto
{
    public Guid Id { get; init; }
    public Guid CategoryId { get; set; }
}
