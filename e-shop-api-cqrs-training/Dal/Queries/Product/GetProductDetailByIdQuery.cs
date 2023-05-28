using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Product;

public class GetProductDetailByIdQuery : IRequest<E.Product>
{
    public Guid Id { get; set; }
}
