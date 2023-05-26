namespace Business.Dtos.User;

public abstract class BaseUserDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
}
