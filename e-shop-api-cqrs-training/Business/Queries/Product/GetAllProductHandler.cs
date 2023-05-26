using Dal.Interfaces;
using Dal.Queries.Product;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

/// <summary>
/// Handler for retrieving all products.
/// </summary>
public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<E.Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllProductHandler"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    public GetAllProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<E.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAsync(cancellationToken);
    }
}
