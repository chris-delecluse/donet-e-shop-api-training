using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetUserRoleQuery : IRequest<IEnumerable<string>>
{
    public AppUser User { get; set; }
}
