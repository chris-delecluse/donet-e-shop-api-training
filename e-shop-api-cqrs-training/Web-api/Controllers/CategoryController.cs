using Business.Dtos.Category;
using Business.Interfaces;
using Dal.Entities;
using Error;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/category")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService) { _categoryService = categoryService; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll()
    {
        var result = await _categoryService.GetAll();

        return Ok(result);
    }

    // mieux gerer les erreurs
    [HttpPost]
    public async Task<ActionResult<CategoryReadDto>> Create(CategoryCreateDto dto)
    {
        try
        {
            var result = await _categoryService.Create(dto);

            return Ok(result);
        }
        catch (ConflictException<Category> e) { return Conflict(new { e.Message }); }
    }
}
