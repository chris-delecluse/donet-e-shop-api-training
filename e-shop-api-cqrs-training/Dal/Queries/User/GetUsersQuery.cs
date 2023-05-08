using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetUsersQuery : IRequest<IEnumerable<AppUser>> { }
