namespace Business.Interfaces;

public interface IAppMapper
{
    TOut ToReadDto<TIn, TOut>(TIn model) where TOut : class;
}
