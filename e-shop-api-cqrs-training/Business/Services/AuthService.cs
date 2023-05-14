using Business.Dtos.Auth;
using Business.Dtos.User;
using Business.Interfaces;
using Business.Validators;
using Dal.Entities;
using Dal.Queries.User;
using Error;
using FluentValidation;
using MediatR;

namespace Business.Services;

public class AuthService : IAuthService
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthService(IMediator mediator, IUserService userService, ITokenService tokenService)
    {
        _mediator = mediator;
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<UserReadDto> Create(UserCreateDto dto) => await _userService.Create(dto);

    public async Task<SignInResponseDto> Authenticate(SignInRequestDto dto)
    {
        await ValidateLoginDto(dto);

        AppUser? user = await _mediator.Send(new GetUserByEmailQuery() { Email = dto.Email });

        if (user is null) throw new UnAuthorizeException("Invalid credentials");

        IEnumerable<string> role = await _mediator.Send(new GetUserRoleQuery() { User = user });

        if (!await _userService.ValidateUserPassword(user, dto.Password))
            throw new UnAuthorizeException("Invalid credentials");

        return _tokenService.GenerateAccessToken(user, role);
    }

    private async Task ValidateLoginDto(SignInRequestDto dto) => await new LoginDtoValidator().ValidateAndThrowAsync(dto);
}
