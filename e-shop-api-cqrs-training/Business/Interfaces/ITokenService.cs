using Business.Dtos.Auth;
using Dal.Entities;

namespace Business.Interfaces;

/// <summary>
/// A service responsible for generating access tokens for authenticated users.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Generates an access token for the specified user and role.
    /// </summary>
    /// <param name="user">The user to generate the access token for.</param>
    /// <param name="role">The role of the user.</param>
    /// <returns>A response DTO containing the access token and its expiration time.</returns>
    SignInResponseDto GenerateAccessToken(AppUser user, IEnumerable<string> role);
}
