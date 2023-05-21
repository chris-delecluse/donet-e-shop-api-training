using Business.Dtos.Product;
using Business.Interfaces;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web_api.Controllers;

[ApiController, Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService) { _productService = productService; }

    // a continué.
    [HttpPost]
    public async Task<ActionResult<Product>> Create(ProductCreateDto productCreateDto)
    {
        return await _productService.Create(productCreateDto);
    }
}
