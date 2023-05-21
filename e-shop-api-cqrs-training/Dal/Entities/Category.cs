namespace Dal.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
