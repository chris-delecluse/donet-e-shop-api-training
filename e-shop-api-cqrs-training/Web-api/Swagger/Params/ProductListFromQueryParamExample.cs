namespace Web_api.Swagger.Params;

public class ProductListFromQueryParamExample
{
    [SwaggerParameter("True")]
    [SwaggerParameter("False")]
    public string? IsDeleted { get; set; }
    
    [SwaggerParameter("Asc")]
    [SwaggerParameter("Desc")]
    public string? SortBy { get; set; }
}
