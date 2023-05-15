using Business.Dtos.Auth;
using Business.Dtos.User;
using Error;

namespace Business.Interfaces;

/// <summary>
/// An interface for handling user authentication and authorization.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Creates a new user account with the specified details.
    /// </summary>
    /// <param name="dto">The details of the user account to create.</param>
    /// <returns>The details of the newly created user account.</returns>
    Task<UserReadDto> Create(UserCreateDto dto);

    /// <summary>
    /// Authenticates a user with the specified email and password.
    /// </summary>
    /// <param name="dto">The email and password of the user to authenticate.</param>
    /// <returns>The authentication token generated for the authenticated user.</returns>
    /// <exception cref="UnAuthorizeException">Thrown when the user cannot be authenticated.</exception>
    Task<SignInResponseDto> Authenticate(SignInRequestDto dto);
}
