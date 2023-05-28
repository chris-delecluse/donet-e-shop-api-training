using Dal.Commands.Product;
using Dal.Interfaces;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Commands.Product;

public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand, string>
{
    private readonly IProductRepository _productRepository;

    public SoftDeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<string> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
    {
        E.Product? product = await _productRepository.FindAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException<E.Product>();
        }
        
        product.IsDeleted = true;
        
        bool isUpdated = await _productRepository.UpdateProductAsync(product, cancellationToken);

        if (!isUpdated)
        {
            throw new BadRequestException<E.Product>();
        }
        
        return $"{nameof(E.Product)} is deleted successfully.";
    }
}
