namespace Dal.Filters;

public class ProductListQueryFilter
{
    public bool? IsDeleted { get; init; }
    public bool? SortByDescending { get; init; }
}
