using Business.Dtos.Category;

namespace Business.Interfaces;

public interface ICategoryService
{
    Task<CategoryReadDto> Create(CategoryCreateDto dto);
    Task<IEnumerable<CategoryReadDto>> GetAll();
    Task<CategoryReadDto> GetOne(Guid guid);
    Task<CategoryReadDto> GetOne(string name);
}
