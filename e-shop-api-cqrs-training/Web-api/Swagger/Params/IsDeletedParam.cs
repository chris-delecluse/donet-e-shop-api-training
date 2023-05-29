namespace Web_api.Swagger.Params;

public class IsDeletedParam
{
    [SwaggerParameter("True", "True")]
    [SwaggerParameter("False", "False")]
    public string? param { get; set; }
}
