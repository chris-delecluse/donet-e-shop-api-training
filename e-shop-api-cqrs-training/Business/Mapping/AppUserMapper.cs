using Business.Dtos.User;
using Business.Interfaces;
using Dal.Entities;

namespace Business.Mapping;

public class AppUserMapper : IAppUserMapper
{
    public UserReadDto ToUserReadDto(AppUser user) => new(user.Id, user.FirstName, user.LastName, user.Email);
}
