namespace Business.Interfaces;

/// <summary>
/// An interface for mapping business models to DTOs.
/// </summary>
public interface IAppMapper
{
    /// <summary>
    /// Maps a model of type <typeparamref name="TIn"/> to a read-only DTO of type <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of the input model to map from.</typeparam>
    /// <typeparam name="TOut">The type of the output DTO to map to.</typeparam>
    /// <param name="model">The input model to map from.</param>
    /// <returns>A new instance of the output DTO mapped from the input model.</returns>
    TOut ToReadDto<TIn, TOut>(TIn model) where TOut : class;
}
