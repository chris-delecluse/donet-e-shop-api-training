using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Product;

public  class GetProductIncludeCategoryById: IRequest<E.Product>
{
    public Guid Id { get; init; }
}
