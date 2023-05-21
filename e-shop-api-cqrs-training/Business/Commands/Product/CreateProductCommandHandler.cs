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

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    public CreateProductCommandHandler(IProductRepository productRepository) { _productRepository = productRepository; }
    
    public async Task<E.Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        E.Product product = new E.Product()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        return await _productRepository.AddAsync(product, cancellationToken);
    }
}