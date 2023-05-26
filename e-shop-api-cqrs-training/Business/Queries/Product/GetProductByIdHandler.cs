using Dal.Interfaces;
using Dal.Queries.Product;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

/// <summary>
/// Handler for retrieving a product by id.
/// </summary>
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, E.Product?>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductByIdHandler"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<E.Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Product>();
    }
}
