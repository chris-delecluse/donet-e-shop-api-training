namespace Business.Dtos.User;

public record UserReadDto(
    string Id,
    string FirstName,
    string LastName,
    string Email
);
