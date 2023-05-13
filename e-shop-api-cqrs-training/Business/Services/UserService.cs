using Business.Dtos.User;
using Business.Interfaces;
using Business.Validators;
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
    private readonly IAppMapper _appMapper;

    public UserService(IMediator mediator, IAppMapper appMapper)
    {
        _mediator = mediator;
        _appMapper = appMapper;
    }

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

       return _appMapper.ToReadDto<AppUser, UserReadDto>(commandResult.User);
    }

    public async Task<IEnumerable<UserReadDto>> GetAll()
    {
        List<UserReadDto> userReadDtoList = new List<UserReadDto>();

        var users = await _mediator.Send(new GetAllUsersQuery());

        foreach (AppUser user in users)
        {
            userReadDtoList.Add(_appMapper.ToReadDto<AppUser, UserReadDto>(user));
        }

        return userReadDtoList;
    }

    public async Task<UserReadDto?> GetOneById(string id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery() { Id = id });
        
        return _appMapper.ToReadDto<AppUser, UserReadDto>(user);
    }

    private async Task ValidateUserCreateDto(UserCreateDto dto) =>
        await new UserCreateDtoValidator().ValidateAndThrowAsync(dto);

    private async Task CheckUserDoesNotExist(string email)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery() { Email = email });

        if (user is not null) throw new ConflictException<AppUser>();
    }
}
