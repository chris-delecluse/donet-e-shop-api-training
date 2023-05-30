using Business.Dtos.Product;
using Business.Interfaces;
using Dal.Entities;
using Dal.Filters;
using Error;
using Microsoft.AspNetCore.Mvc;
using Web_api.Swagger.Params;

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
    public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll(
        [FromQuery] ProductListFromQueryParamExample queryParamExample
    )
    {
        // deplacer la logique d'assignation filtrage dans le service.

        bool? sortBy = null;

        if (queryParamExample.SortBy == "asc")
        {
            sortBy = false;
        }
        else if (queryParamExample.SortBy == "desc")
        {
            sortBy = true;
        }
        else
        {
            sortBy = null;
        }

        Console.WriteLine(queryParamExample.Search);
        
        ProductListQueryFilters filters = new ProductListQueryFilters
        {
            IsDeleted = queryParamExample.IsDeleted, 
            SortByDescending = sortBy
        };

        IEnumerable<ProductReadDto> result = await _productService.GetAll(filters);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductReadDto>> GetOne(Guid id)
    {
        try
        {
            ProductReadDto? result = await _productService.GetOne(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<ProductDetailReadDto>> GetOneWithFullDetails(Guid id)
    {
        try
        {
            ProductDetailReadDto? result = await _productService.GetOneWithDetails(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/category")]
    public async Task<ActionResult<ProductWithCategoryReadDto>> GetOneWithCategory(Guid id)
    {
        try
        {
            ProductWithCategoryReadDto? result = await _productService.GetOneIncludeCategory(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpGet("{id}/stock")]
    public async Task<ActionResult<ProductWithStockReadDto>> GetOneWithStock(Guid id)
    {
        try
        {
            ProductWithStockReadDto? result = await _productService.GetOneIncludeStock(id);
            return Ok(result);
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<string>> SoftDeleteOne(Guid id)
    {
        try
        {
            string result = await _productService.SoftDeleteProduct(id);
            return Ok(new { result });
        }
        catch (NotFoundException<Product> e) { return NotFound(new { e.Message }); }
        catch (BadRequestException<Product> e) { return BadRequest(new { e.Message }); }
    }
}
