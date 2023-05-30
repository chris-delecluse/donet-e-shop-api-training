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
                IOpenApiAny? exampleValue = null;

                if (item.Value is string valueString)
                {
                    exampleValue = new OpenApiString(valueString);
                }
                else if (item.Value is bool valueBool)
                {
                    exampleValue = new OpenApiBoolean(valueBool);
                }
                else if (item.Value is int valueInt)
                {
                    exampleValue = new OpenApiInteger(valueInt);
                }

                OpenApiExample? example = new OpenApiExample
                {
                    Description = item.Description,
                    Value = exampleValue
                };

                parameter.Examples.Add(item.Name, example);
            }
        }
    }
}
