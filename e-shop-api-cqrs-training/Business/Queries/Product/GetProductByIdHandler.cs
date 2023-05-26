using Dal.Interfaces;
using Dal.Queries.Product;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, E.Product?>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository) { _productRepository = productRepository; }

    public async Task<E.Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Product>();
    }
}
