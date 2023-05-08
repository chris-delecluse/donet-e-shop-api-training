using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetUserQuery : IRequest<AppUser>
{
    public string Id { get; set; }
    public string? Email { get; set; }
}
