using Dal.Interfaces;
using Dal.Queries.Product;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, IEnumerable<E.Product>>
{
    private readonly IProductRepository _productRepository;

    public GetAllProductHandler(IProductRepository productRepository) { _productRepository = productRepository; }

    public async Task<IEnumerable<E.Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAsync(cancellationToken);
    }
}
