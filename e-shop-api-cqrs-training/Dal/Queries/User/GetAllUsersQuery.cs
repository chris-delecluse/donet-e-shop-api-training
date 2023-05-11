using Dal.Entities;
using MediatR;

namespace Dal.Queries.User;

public class GetAllUsersQuery : IRequest<IEnumerable<AppUser>> { }
