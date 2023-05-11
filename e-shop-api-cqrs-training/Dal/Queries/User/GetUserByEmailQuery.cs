using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetUserByEmailQuery : IRequest<AppUser?>
{
    public string Email { get; set; }
}
