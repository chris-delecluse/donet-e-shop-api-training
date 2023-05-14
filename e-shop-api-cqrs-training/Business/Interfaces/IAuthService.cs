using Business.Dtos.Auth;
using Business.Dtos.User;

namespace Business.Interfaces;

public interface IAuthService
{
    Task<UserReadDto> Create(UserCreateDto dto);
    Task<SignInResponseDto> Authenticate(SignInRequestDto dto);
}