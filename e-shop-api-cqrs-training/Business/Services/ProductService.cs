using AutoMapper;
using Business.Dtos.Product;
using Business.Interfaces;
using Business.Validators;
using Dal.Commands.Product;
using Dal.Entities;
using Dal.Filters;
using Dal.Queries.Product;
using FluentValidation;
using MediatR;

namespace Business.Services;

public class ProductService : IProductService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ProductReadDto> Create(ProductCreateDto productCreateDto)
    {
        await new ProductCreateDtoValidator().ValidateAndThrowAsync(productCreateDto);

        var command = new CreateProductCommand()
        {
            Name = productCreateDto.Name,
            Description = productCreateDto.Description,
            Price = productCreateDto.Price,
            CategoryId = productCreateDto.CategoryId,
            Quantity = productCreateDto.Quantity
        };

        Product? product = await _mediator.Send(command);

        return _mapper.Map<ProductReadDto>(product);
    }

    public async Task<IEnumerable<ProductReadDto>> GetAll(ProductListQueryFilters filters)
    {
        IEnumerable<Product> command = await _mediator.Send(new GetAllProductQuery { Filter = filters });
        return _mapper.Map<IEnumerable<ProductReadDto>>(command);
    }

    public async Task<ProductReadDto?> GetOne(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductByIdQuery { Id = guid });
        return _mapper.Map<ProductReadDto>(product);
    }

    public async Task<ProductDetailReadDto?> GetOneWithDetails(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductDetailByIdQuery { Id = guid });
        return _mapper.Map<ProductDetailReadDto>(product);
    }

    public async Task<ProductWithCategoryReadDto?> GetOneIncludeCategory(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductIncludeCategoryByIdQuery { Id = guid });
        return _mapper.Map<ProductWithCategoryReadDto>(product);
    }

    public async Task<ProductWithStockReadDto?> GetOneIncludeStock(Guid guid)
    {
        Product? product = await _mediator.Send(new GetProductIncludeStockByIdQuery { Id = guid });
        return _mapper.Map<ProductWithStockReadDto>(product);
    }

    public async Task<string> SoftDeleteProduct(Guid guid)
    {
        return await _mediator.Send(new SoftDeleteProductCommand { Id = guid });
    }
}
