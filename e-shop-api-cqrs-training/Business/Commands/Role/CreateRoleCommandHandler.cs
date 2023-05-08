using Dal.Commands.Role;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Commands.Role;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IdentityResult>
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager) { _roleManager = roleManager; }

    public async Task<IdentityResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleManager.CreateAsync(new IdentityRole(request.Name));
    }
}
