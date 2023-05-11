namespace Business.Interfaces;

public interface IAppMapper
{
    public TOut ToReadDto<TIn, TOut>(TIn model) where TOut : class;
}
