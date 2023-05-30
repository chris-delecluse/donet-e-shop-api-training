namespace Web_api.Swagger;

[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = true)]
public class SwaggerParameterAttribute : Attribute
{
    public string Name { get; set; }
    public object? Value { get; set; }
    public string? Description { get; set; }

    public SwaggerParameterAttribute(string name)
    {
        Name = name;
        Value = name;
    }

    public SwaggerParameterAttribute(string name, object? value)
    {
        Name = name;
        Value = value;
    }

    public SwaggerParameterAttribute(string name, object? value, string description)
    {
        Name = name;
        Value = value;
        Description = description;
    }
}
