using Business.Interfaces;

namespace Business.Mappings;

/// <summary>
/// Defines a mapper that can transform a model of type <typeparamref name="TIn"/> into a read-only DTO of type <typeparamref name="TOut"/>.
/// </summary>
public class AppMapper : IAppMapper
{
    public TOut ToReadDto<TIn, TOut>(TIn model) where TOut : class
    {
        var destinationType = typeof(TOut);
        var sourceType = typeof(TIn);

        var destination = Activator.CreateInstance(destinationType);

        foreach (var sourceProperty in sourceType.GetProperties())
        {
            var destinationProperty = destinationType.GetProperty(sourceProperty.Name);

            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                var sourceValue = sourceProperty.GetValue(model);

                if (IsComplexType(sourceProperty.PropertyType))
                {
                    var nestedDtoType = destinationProperty.PropertyType;
                    var nestedDto = typeof(AppMapper)
                        .GetMethod("ToReadDto")
                        ?.MakeGenericMethod(sourceProperty.PropertyType, nestedDtoType)
                        .Invoke(this, new[] { sourceValue });
                    destinationProperty.SetValue(destination, nestedDto);
                }
                else { destinationProperty.SetValue(destination, sourceValue); }
            }
        }

        return (TOut)destination;
    }

    private bool IsComplexType(Type type) => type.IsClass && type != typeof(string);
}
