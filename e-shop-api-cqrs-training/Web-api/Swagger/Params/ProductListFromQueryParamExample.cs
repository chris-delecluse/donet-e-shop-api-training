namespace Web_api.Swagger.Params;

public class ProductListFromQueryParamExample
{
    [SwaggerParameter("true")]
    [SwaggerParameter("false")]
    public bool? IsDeleted { get; set; }

    [SwaggerParameter("asc")]
    [SwaggerParameter("desc")]
    public string? SortBy { get; set; }

    public string? Search { get; set; }
}
