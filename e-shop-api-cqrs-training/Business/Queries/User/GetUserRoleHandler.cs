using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Queries.User;

public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, IEnumerable<string>>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserRoleHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<IEnumerable<string>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.GetRolesAsync(request.User);
    }
}
