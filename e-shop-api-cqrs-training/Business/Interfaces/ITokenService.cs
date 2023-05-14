using Business.Dtos.Auth;
using Dal.Entities;

namespace Business.Interfaces;

public interface ITokenService
{
    SignInResponseDto GenerateAccessToken(AppUser user, IEnumerable<string> role);
}
