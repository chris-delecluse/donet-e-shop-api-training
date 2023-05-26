using Business.Dtos.Product;
using Business.Interfaces;
using Business.Validators;
using Dal.Commands.Product;
using Dal.Entities;
using Dal.Queries.Product;
using FluentValidation;
using MediatR;

namespace Business.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IAppMapper _appMapper;

    public ProductService(IMediator mediator, IAppMapper appMapper)
    {
        _mediator = mediator;
        _appMapper = appMapper;
    }

    public async Task<ProductReadDto> Create(ProductCreateDto productCreateDto)
    {
        await new ProductCreateDtoValidator().ValidateAndThrowAsync(productCreateDto);

        var command = new CreateProductCommand()
        {
            Name = productCreateDto.Name,
            Description = productCreateDto.Description,
            Price = productCreateDto.Price,
            CategoryId = productCreateDto.CategoryId
        };

        Product? product = await _mediator.Send(command);

        return _appMapper.ToReadDto<Product, ProductReadDto>(product);
    }

    public async Task<IEnumerable<ProductReadDto>> GetAll()
    {
        List<ProductReadDto> list = new List<ProductReadDto>();
        IEnumerable<Product> command = await _mediator.Send(new GetAllProductQuery());

        foreach (Product product in command)
        {
            list.Add(_appMapper.ToReadDto<Product, ProductReadDto>(product));
        }

        return list;
    }

    public async Task<ProductReadDto?> GetOne(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductByIdQuery { Id = guid });
        return _appMapper.ToReadDto<Product, ProductReadDto>(product);
    }

    public async Task<ProductDetailReadDto?> GetOneIncludeCategory(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductIncludeCategoryById { Id = guid });
        return _appMapper.ToReadDto<Product, ProductDetailReadDto>(product);
    }
}
