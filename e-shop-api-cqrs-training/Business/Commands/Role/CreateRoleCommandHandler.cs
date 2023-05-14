using Dal.Commands.Role;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Commands.Role;

/// <summary>
/// Handler for creating a new role.
/// </summary>
public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IdentityResult>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRoleCommandHandler"/> class.
    /// </summary>
    /// <param name="roleManager">The role manager.</param>
    public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager) { _roleManager = roleManager; }


    /// <summary>
    /// Handles the specified create role command.
    /// </summary>
    /// <param name="request">The create role command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task containing the result of creating the role.</returns>
    public async Task<IdentityResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleManager.CreateAsync(new IdentityRole(request.Name));
    }
}
