using Business.Dtos.Category;

namespace Business.Interfaces;

public interface ICategoryService
{
    Task<CategoryReadDto> Create(CategoryCreateDto dto);
    Task<CategoryReadDto> GetOne(string name);
}
