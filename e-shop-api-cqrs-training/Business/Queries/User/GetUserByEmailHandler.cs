using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Queries.User;

/// <summary>
/// Handler for retrieving an <see cref="AppUser"/> by email address.
/// </summary>
public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, AppUser?>
{
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserByEmailHandler"/> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public GetUserByEmailHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    /// <inheritdoc/>
    public async Task<AppUser?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(request.Email);
    }
}
