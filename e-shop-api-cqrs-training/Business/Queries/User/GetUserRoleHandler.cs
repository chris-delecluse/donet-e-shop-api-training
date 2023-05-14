using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Queries.User;

/// <summary>
/// Handler for retrieving the roles of an <see cref="AppUser"/>.
/// </summary>
public class GetUserRoleHandler : IRequestHandler<GetUserRoleQuery, IEnumerable<string>>
{
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserRoleHandler"/> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public GetUserRoleHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    /// <inheritdoc/>
    public async Task<IEnumerable<string>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.GetRolesAsync(request.User);
    }
}
