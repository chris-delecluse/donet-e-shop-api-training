using Business.Interfaces;

namespace Business.Mappings;

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
