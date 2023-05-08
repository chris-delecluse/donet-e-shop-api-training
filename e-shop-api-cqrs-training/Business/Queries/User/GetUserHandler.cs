using Dal.Entities;
using Dal.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.User;

public class GetUserHandler : IRequestHandler<GetUserQuery, AppUser?>
{
    private readonly UserManager<AppUser> _userManager;

    public GetUserHandler(UserManager<AppUser> userManager) { _userManager = userManager; }

    public async Task<AppUser?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        AppUser? query = null;
        
        if (!string.IsNullOrEmpty(request.Id))
        {
            query = await _userManager.Users.FirstAsync(u => u.Id == request.Id);
        }
        else if (!string.IsNullOrEmpty(request.Email))
        {
            query = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
        }

        return query;
    }
}
