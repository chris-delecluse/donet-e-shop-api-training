using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Product;

public class GetProductIncludeCategoryByIdQuery : IRequest<E.Product>
{
    public Guid Id { get; init; }
}
