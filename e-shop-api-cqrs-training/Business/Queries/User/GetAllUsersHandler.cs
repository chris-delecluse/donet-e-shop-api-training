using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

/// <summary>
/// Handles the logic for retrieving all users.
/// </summary>
public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AppUser>>
{
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllUsersHandler"/> class.
    /// </summary>
    /// <param name="userManager">The <see cref="UserManager{TUser}"/> used to manage user accounts.</param>
    public GetAllUsersHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    /// <inheritdoc/>
    public async Task<IEnumerable<AppUser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users.ToListAsync(cancellationToken);
    }
}
