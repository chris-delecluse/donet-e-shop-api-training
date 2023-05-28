using Dal.Interfaces;
using Dal.Queries.Product;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Product;

public class GetProductIncludeStockByIdHandler : IRequestHandler<GetProductIncludeStockByIdQuery, E.Product?>
{
    private readonly IProductRepository _productRepository;

    public GetProductIncludeStockByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<E.Product?> Handle(GetProductIncludeStockByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.FindAndIncludeStockAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Product>();
    }
}
