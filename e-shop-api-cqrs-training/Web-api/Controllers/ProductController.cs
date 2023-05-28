using Business.Dtos.Product;
using Business.Interfaces;
using Dal.Entities;
using Error;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) { _productService = productService; }

    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto dto)
    {
        try
        {
            var result = await _productService.Create(dto);
            return Created($"api/product/{result.Id}", result);
        }
        catch (Exception e) { return BadRequest(new { e.Message }); }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
    {
        return Ok(await _productService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetOne(Guid id)
    {
        try
        {
            var result = await _productService.GetOne(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<ProductDetailReadDto>> GetOneWithFullDetails(Guid id)
    {
        try
        {
            var result = await _productService.GetOneWithDetails(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/category")]
    public async Task<ActionResult<ProductWithCategoryReadDto>> GetOneWithCategory(Guid id)
    {
        try
        {
            var result = await _productService.GetOneIncludeCategory(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/stock")]
    public async Task<ActionResult<ProductWithStockReadDto>> GetOneWithStock(Guid id)
    {
        try
        {
            var result = await _productService.GetOneIncludeStock(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }
}
