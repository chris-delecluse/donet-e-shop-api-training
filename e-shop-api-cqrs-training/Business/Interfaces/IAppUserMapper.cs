using Business.Dtos.User;
using Dal.Entities;

namespace Business.Interfaces;

public interface IAppUserMapper
{
    public UserReadDto ToUserReadDto(AppUser appUser);
}
