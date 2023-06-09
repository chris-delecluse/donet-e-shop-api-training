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

/// <summary>
/// This service handles authentication for users.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class.
    /// </summary>
    /// <param name="mediator">An instance of <see cref="IMediator"/> used to send queries and commands.</param>
    /// <param name="userService">An instance of <see cref="IUserService"/> used to manage user accounts.</param>
    /// <param name="tokenService">An instance of <see cref="ITokenService"/> used to generate authentication tokens.</param>
    public AuthService(IMediator mediator, IUserService userService, ITokenService tokenService)
    {
        _mediator = mediator;
        _userService = userService;
        _tokenService = tokenService;
    }

    public async Task<UserReadDto> Register(UserCreateDto dto)
    {
        return await _userService.Create(dto);
    }

    public async Task<SignInResponseDto> Authenticate(SignInRequestDto dto)
    {
        await new LoginDtoValidator().ValidateAndThrowAsync(dto);

        AppUser? user = await _mediator.Send(new GetUserByEmailQuery() { Email = dto.Email });

        if (user is null) throw new UnAuthorizeException("Invalid credentials");

        IEnumerable<string> role = await _mediator.Send(new GetUserRoleQuery() { User = user });

        if (!await _userService.ValidateUserPassword(user, dto.Password))
            throw new UnAuthorizeException("Invalid credentials");

        return _tokenService.GenerateAccessToken(user, role);
    }
}
