namespace Business.Dtos.Product;

public class ProductCreateDto : BaseProductDto
{
    public Guid CategoryId { get; init; }
}
