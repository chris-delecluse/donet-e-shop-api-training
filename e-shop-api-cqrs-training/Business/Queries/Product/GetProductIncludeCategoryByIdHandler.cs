using Dal.Interfaces;
using Dal.Queries.Product;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

/// <summary>
/// Handler for retrieving a product include category by product id.
/// </summary>
public class GetProductIncludeCategoryByIdHandler: IRequestHandler<GetProductIncludeCategoryByIdQuery, E.Product?>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductIncludeCategoryByIdQuery"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    public GetProductIncludeCategoryByIdHandler(IProductRepository productRepository) { _productRepository = productRepository; }

    public async Task<E.Product?> Handle(GetProductIncludeCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAndIncludeCategoryAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Product>();
    }
}
