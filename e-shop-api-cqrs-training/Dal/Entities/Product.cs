namespace Dal.Entities;

// public class Product : BaseEntity
// {
//     public string Name { get; set; }
//     public string Description { get; set; }
//     public decimal Price { get; set; }
//
//     public int CategoryId { get; set; }
//     public Category Category { get; set; }
//
//     public int StockId { get; set; }
//     public Stock Stock { get; set; }
//
//     public ICollection<ProductImage> Images { get; set; }
//     public ICollection<Review> Reviews { get; set; }
// }

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
