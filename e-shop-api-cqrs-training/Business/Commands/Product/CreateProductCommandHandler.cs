using Dal.Commands.Product;
using Dal.Interfaces;
using MediatR;
using E = Dal.Entities;

namespace Business.Commands.Product;

/// <summary>
/// Handler for creating a new product.
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, E.Product>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<E.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        E.Product product = new E.Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId,
            ProductStock = new E.ProductStock { Quantity = request.Quantity },
            Category = await _categoryRepository.FindAsync(request.CategoryId, cancellationToken)
        };

        return await _productRepository.AddAsync(product, cancellationToken);
    }
}
