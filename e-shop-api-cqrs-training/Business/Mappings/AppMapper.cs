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
                destinationProperty.SetValue(destination, sourceProperty.GetValue(model));
        }

        return (TOut)destination;
    }
}
