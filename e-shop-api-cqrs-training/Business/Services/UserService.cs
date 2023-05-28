using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Constructor for UserService class.
    /// </summary>
    /// <param name="mediator">An instance of IMediator used for sending MediatR requests and receiving responses.</param>
    /// <param name="mapper">An instance of IMapper used for mapping objects between the application and domain layers.</param>
    /// <param name="userManager">An instance of UserManager used for managing user authentication and authorization.</param>
    public UserService(IMediator mediator, IMapper mapper, UserManager<AppUser> userManager)
    {
        _mediator = mediator;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserReadDto> Create(UserCreateDto dto)
    {
        await new UserCreateDtoValidator().ValidateAndThrowAsync(dto);
        await CheckUserDoesNotExist(dto.Email);

        var command = new CreateUserCommand()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            UserName = dto.Email,
            Email = dto.Email,
            Password = dto.Password
        };
        AppUser user = await _mediator.Send(command);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<IEnumerable<UserReadDto>> GetAll()
    {
        IEnumerable<AppUser> users = await _mediator.Send(new GetAllUsersQuery());
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public async Task<UserReadDto?> GetOneById(string id)
    {
        AppUser? user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<bool> ValidateUserPassword(AppUser user, string passwordEntry)
    {
        return await _userManager.CheckPasswordAsync(user, passwordEntry);
    }

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
