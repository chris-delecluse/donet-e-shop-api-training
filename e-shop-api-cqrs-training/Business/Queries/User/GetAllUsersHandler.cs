using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AppUser>>
{
    private readonly UserManager<AppUser> _userManager;

    public GetAllUsersHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<IEnumerable<AppUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users.ToListAsync(cancellationToken);
    }
}
