using Business.Dtos.Category;
using Dal.Entities;

namespace Business.Interfaces;

public interface ICategoryService
{
    Task<CategoryReadDto> Create(CategoryCreateDto dto);
    Task<IEnumerable<CategoryReadDto>> GetAll();
    Task<CategoryReadDto> GetOne(string name);
}
