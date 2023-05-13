using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetUserByIdQuery : IRequest<AppUser>
{
    public string? Id { get; set; }
}
