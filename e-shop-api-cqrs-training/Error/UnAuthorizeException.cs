namespace Error;

public class UnAuthorizeException : Exception
{
    public UnAuthorizeException(string message) : base(message) { }
}
