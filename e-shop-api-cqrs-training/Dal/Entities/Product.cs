namespace Dal.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid ProductStockId { get; set; }
    public ProductStock? ProductStock { get; set; }
}
