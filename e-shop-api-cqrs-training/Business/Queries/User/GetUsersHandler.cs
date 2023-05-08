using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<AppUser>>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUsersHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<IEnumerable<AppUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users.ToListAsync();
    }
}
