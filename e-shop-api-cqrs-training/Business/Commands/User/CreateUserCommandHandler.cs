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

        await _userManager.CreateAsync(user, request.Password);

        return new CreateUserCommandResult() { User = user };
    }
}
