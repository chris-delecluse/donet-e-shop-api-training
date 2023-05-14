using Business.Dtos.User;
using Business.Interfaces;
using Business.Validators;
using Dal.Commands.User;
using Dal.Entities;
using Dal.Queries.User;
using Error;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

/// <summary>
/// Service for managing user-related operations.
/// </summary>
public class UserService : IUserService
{
    private readonly IMediator _mediator;
    private readonly IAppMapper _appMapper;
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Constructor for UserService class.
    /// </summary>
    /// <param name="mediator">An instance of IMediator used for sending MediatR requests and receiving responses.</param>
    /// <param name="appMapper">An instance of IAppMapper used for mapping objects between the application and domain layers.</param>
    /// <param name="userManager">An instance of UserManager used for managing user authentication and authorization.</param>
    public UserService(IMediator mediator, IAppMapper appMapper, UserManager<AppUser> userManager)
    {
        _mediator = mediator;
        _appMapper = appMapper;
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<UserReadDto> Create(UserCreateDto dto)
    {
        ValidateUserCreateDto(dto);
        await CheckUserDoesNotExist(dto.Email);

        var userCommand = new CreateUserCommand()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.Email,
            Email = dto.Email,
            Password = dto.Password
        };
        var commandResult = await _mediator.Send(userCommand);

        return _appMapper.ToReadDto<AppUser, UserReadDto>(commandResult.User);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<UserReadDto>> GetAll()
    {
        List<UserReadDto> userReadDtoList = new List<UserReadDto>();

        IEnumerable<AppUser> users = await _mediator.Send(new GetAllUsersQuery());

        foreach (AppUser user in users) { userReadDtoList.Add(_appMapper.ToReadDto<AppUser, UserReadDto>(user)); }

        return userReadDtoList;
    }

    /// <inheritdoc/>
    public async Task<UserReadDto?> GetOneById(string id)
    {
        AppUser? user = await _mediator.Send(new GetUserByIdQuery() { Id = id });

        return _appMapper.ToReadDto<AppUser, UserReadDto>(user);
    }

    /// <inheritdoc/>
    public async Task<bool> ValidateUserPassword(AppUser user, string passwordEntry) =>
        await _userManager.CheckPasswordAsync(user, passwordEntry);

    /// <summary>
    /// Validates a user creation DTO using a validator and throws an exception if the data is not valid.
    /// </summary>
    /// <param name="dto">The user creation DTO to validate.</param>
    private void ValidateUserCreateDto(UserCreateDto dto) => new UserCreateDtoValidator().ValidateAndThrowAsync(dto);

    /// <summary>
    /// Checks if a user with the given email address exists in the database and throws a conflict exception if it does.
    /// </summary>
    /// <param name="email">The email address to check for.</param>
    private async Task CheckUserDoesNotExist(string email)
    {
        AppUser? user = await _mediator.Send(new GetUserByEmailQuery() { Email = email });

        if (user is not null) throw new ConflictException<AppUser>();
    }
}
