using Business.Enums;
using Dal.Commands.User;
using Dal.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Commands.User;

/// <summary>
/// Handler for creating a new user.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserCommandHandler"/> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public CreateUserCommandHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    /// <summary>
    /// Handles the specified create user command.
    /// </summary>
    /// <param name="request">The create user command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task containing the result of creating the user.</returns>
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
