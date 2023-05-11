using Business.Dtos.User;
using Business.Interfaces;
using Dal.Entities;

namespace Business.Mappings;

public class AppUserMapper : IAppUserMapper
{
    public UserReadDto ToUserReadDto(AppUser user) => new(user.Id, user.FirstName, user.LastName, user.Email);
}
