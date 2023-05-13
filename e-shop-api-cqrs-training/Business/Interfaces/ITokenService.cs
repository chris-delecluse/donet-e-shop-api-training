using Business.Dtos.Auth;
using Dal.Entities;

namespace Business.Interfaces;

public interface ITokenService
{
    TokenDto GenerateAccessToken(AppUser user, IEnumerable<string> role);
}
