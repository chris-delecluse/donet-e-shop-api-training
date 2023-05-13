using Business.Dtos.User;
using Dal.Entities;

namespace Business.Interfaces;

public interface IUserService
{
    Task<UserReadDto> Create(UserCreateDto dto);
    Task<IEnumerable<UserReadDto>> GetAll();
    Task<UserReadDto?> GetOneById(string id);
}
