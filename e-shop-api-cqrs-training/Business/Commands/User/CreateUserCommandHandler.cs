using Business.Enums;
using Dal.Commands.User;
using Dal.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Commands.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly UserManager<AppUser> _userManager;

    public CreateUserCommandHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<CreateUserCommandResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email
        };

        var commandResult = await _userManager.CreateAsync(user, request.Password);

        if (commandResult.Succeeded) await _userManager.AddToRoleAsync(user, RoleName.Customer.ToString());

        return new CreateUserCommandResult() { User = user };
    }
}
