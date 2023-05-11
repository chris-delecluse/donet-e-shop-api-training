using Business.Dtos.User;

namespace Business.Interfaces;

public interface IUserService
{
    public Task<UserReadDto> Create(UserCreateDto dto);
    public Task<IEnumerable<UserReadDto>> GetAll();
    public Task<UserReadDto?> GetOneById(string id);
}
