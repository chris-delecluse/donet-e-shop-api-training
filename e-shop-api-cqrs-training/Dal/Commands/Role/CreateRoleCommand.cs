using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Dal.Commands.Role;

public class CreateRoleCommand: IRequest<IdentityResult>
{
    public string Name { get; set; }
}
