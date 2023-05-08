namespace Error;

public class NotFoundException<T> : Exception
{
    public NotFoundException() : base($"Not found error: {typeof(T).Name} do not exists.") { }
}
