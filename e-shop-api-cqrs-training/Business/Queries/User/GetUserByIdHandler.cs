using Dal.Entities;
using Dal.Queries.User;
using Error;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

/// <summary>
/// Handler for retrieving an <see cref="AppUser"/> by ID.
/// </summary>
public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, AppUser?>
{
    private readonly UserManager<AppUser> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserByIdHandler"/> class.
    /// </summary>
    /// <param name="userManager">The user manager.</param>
    public GetUserByIdHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    /// <inheritdoc/>
    public async Task<AppUser?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
               throw new NotFoundException<AppUser>();
    }
}
