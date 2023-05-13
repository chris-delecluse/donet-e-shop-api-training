using Business.Dtos.Auth;
using Business.Dtos.User;
using Business.Interfaces;
using Business.Validators;
using Dal.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(
        IUserService userService,
        ITokenService tokenService,
        UserManager<AppUser> userManager
    )
    {
        _userService = userService;
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<UserReadDto> Create(UserCreateDto dto) { return await _userService.Create(dto); }

    public async Task<TokenDto> Authenticate(LoginDto dto)
    {
        await ValidateLoginDto(dto);

        AppUser? user = await _userManager.FindByEmailAsync(dto.Email);
        IEnumerable<string> role = await _userManager.GetRolesAsync(user);

        if (await ValidateUser(user, dto.Password) == false) throw new Exception();

        return _tokenService.GenerateAccessToken(user, role);
    }

    private async Task ValidateLoginDto(LoginDto dto) => await new LoginDtoValidator().ValidateAndThrowAsync(dto);

    private async Task<bool> ValidateUser(AppUser user, string password) =>
        await _userManager.CheckPasswordAsync(user, password);
}
