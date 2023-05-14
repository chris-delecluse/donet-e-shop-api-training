using Business.Dtos.User;
using Dal.Entities;

namespace Business.Interfaces;

/// <summary>
/// An interface for interacting with user entities.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="dto">Data to create the user.</param>
    /// <returns>The newly created user.</returns>
    Task<UserReadDto> Create(UserCreateDto dto);

    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns>A list of all users.</returns>
    Task<IEnumerable<UserReadDto>> GetAll();

    /// <summary>
    /// Gets a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to get.</param>
    /// <returns>The user with the specified ID, or null if no user was found.</returns>
    Task<UserReadDto?> GetOneById(string id);

    /// <summary>
    /// Validates a user's password.
    /// </summary>
    /// <param name="user">The user to validate the password for.</param>
    /// <param name="passwordEntry">The password to validate.</param>
    /// <returns>True if the password is valid, otherwise false.</returns>
    Task<bool> ValidateUserPassword(AppUser user, string passwordEntry);
}
