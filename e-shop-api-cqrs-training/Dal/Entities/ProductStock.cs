namespace Dal.Entities;

public class ProductStock: BaseEntity
{
    public int Quantity { get; set; }
    public Product Product { get; set; }
}
