namespace Error;

public class ConflictException<T> : Exception
{
    public ConflictException() : base($"Conflict error: '{typeof(T).Name}' already exists.") { }
}
