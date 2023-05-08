using Business.Dtos.User;
using Business.Interfaces;
using Business.Validator;
using Dal.Commands.User;
using Dal.Entities;
using Dal.Queries.User;
using Error;
using FluentValidation;
using MediatR;

namespace Business.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;

    public UserService(IMediator mediator) { _mediator = mediator; }

    public async Task<UserReadDto> Create(UserCreateDto dto)
    {
        await ValidateUserCreateDto(dto);
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

        return new UserReadDto(commandResult.User.Id,
            commandResult.User.FirstName,
            commandResult.User.LastName,
            commandResult.User.Email
        );
    }

    public async Task<IEnumerable<UserReadDto>> GetAll()
    {
        var usersQuery = new GetUsersQuery();

        var result = await _mediator.Send(usersQuery);

        List<UserReadDto> list = new List<UserReadDto>();

        foreach (AppUser user in result)
        {
            list.Add(new UserReadDto(user.Id, user.FirstName, user.LastName, user.Email));
        }

        return list;
    }

    public async Task<UserReadDto?> GetOne(string id)
    {
        var userQuery = new GetUserQuery() { Id = id };

        var result = await _mediator.Send(userQuery);

        return new UserReadDto(result.Id, result.FirstName, result.LastName, result.Email);
    }

    private async Task ValidateUserCreateDto(UserCreateDto dto)
    {
        UserCreateDtoValidator validator = new UserCreateDtoValidator();

        await validator.ValidateAndThrowAsync(dto);
    }

    private async Task CheckUserDoesNotExist(string email)
    {
        var userQuery = new GetUserQuery() { Email = email };
        var user = await _mediator.Send(userQuery);

        if (user is not null) throw new ConflictException<AppUser>();
    }
}
