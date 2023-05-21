using Business.Dtos.Product;
using Business.Interfaces;
using Dal.Commands.Product;
using Dal.Entities;
using MediatR;

namespace Business.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator) { _mediator = mediator; }

    // a continué (validation ect..)
    public async Task<Product> Create(ProductCreateDto productCreateDto)
    {
        var command = new CreateProductCommand()
        {
            Name = productCreateDto.Name,
            Description = productCreateDto.Description,
            Price = productCreateDto.Price
        };

        return await _mediator.Send(command);
    }
}
