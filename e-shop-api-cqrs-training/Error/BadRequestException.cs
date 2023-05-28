namespace Error;

public class BadRequestException<T> : Exception
{
    public BadRequestException() : base($"The request on {typeof(T).Name} failed due to a bad request error.") { }
}
