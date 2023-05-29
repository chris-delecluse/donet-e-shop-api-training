using System.Reflection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Web_api.Swagger;

internal class CustomSwaggerParameterFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        IEnumerable<SwaggerParameterAttribute>? parameterAttributes = null;

        if (context.PropertyInfo is not null)
        {
            parameterAttributes = context.PropertyInfo.GetCustomAttributes<SwaggerParameterAttribute>();
        }
        else if (context.ParameterInfo is not null)
        {
            parameterAttributes = context.ParameterInfo.GetCustomAttributes<SwaggerParameterAttribute>();
        }

        if (parameterAttributes is not null && parameterAttributes.Any())
        {
            parameter.Examples.Add("--", 
                new OpenApiExample
                {
                    Value = new OpenApiNull(), 
                    Description = "No query parameter selected."
                }
            );

            foreach (var item in parameterAttributes)
            {
                OpenApiExample? example = new OpenApiExample
                {
                    Description = item.Description, 
                    Value = new OpenApiString((item.Value?.ToString()))
                };

                parameter.Examples.Add(item.Name, example);
            }
        }
    }
}
