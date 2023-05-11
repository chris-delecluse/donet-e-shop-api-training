using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, AppUser?>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserByIdHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<AppUser?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.Users.FirstAsync(x => x.Id == request.Id, cancellationToken);
    }
}
