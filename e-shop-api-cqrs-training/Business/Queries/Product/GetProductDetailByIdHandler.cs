using Dal.Interfaces;
using Dal.Queries.Product;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

public class GetProductDetailByIdHandler : IRequestHandler<GetProductDetailByIdQuery, E.Product?>
{
    private readonly IProductRepository _productRepository;

    public GetProductDetailByIdHandler(IProductRepository productRepository) { _productRepository = productRepository; }

    public async Task<E.Product?> Handle(GetProductDetailByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAndIncludeFulLDetailAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Product>();
    }
}
