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

    // mieux gerer les erreurs
    [HttpGet("{name}")]
    public async Task<ActionResult<Category>> GetOne(string name)
    {
        try
        {
            var result = await _categoryService.GetOne(name);

            return Ok(result);
        }
        catch (NotFoundException<Category> e) { return NotFound(new { e.Message }); }
    }
}
