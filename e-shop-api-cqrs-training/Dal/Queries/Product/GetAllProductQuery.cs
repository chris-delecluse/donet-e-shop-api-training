using Dal.Filters;
using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Product;

public class GetAllProductQuery : IRequest<IEnumerable<E.Product>>
{
    public ProductListQueryFilters? Filter { get; init; }
}
