using Dal.Entities;
using Dal.Queries.User;
using Error;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, AppUser?>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserByEmailHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<AppUser?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _userManager.FindByEmailAsync(request.Email) ??
               throw new NotFoundException<AppUser>();
    }
}
