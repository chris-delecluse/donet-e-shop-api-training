using Dal.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Dal.Commands.User;

public class CreateUserCommand : IRequest<AppUser>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
