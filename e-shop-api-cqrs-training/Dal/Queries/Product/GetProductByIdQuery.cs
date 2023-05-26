using MediatR;
using E = Dal.Entities;
namespace Dal.Queries.Product;

public class GetProductByIdQuery: IRequest<E.Product>
{
    public Guid Id { get; init; }
}
