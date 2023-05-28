using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Product;

public class GetProductIncludeStockByIdQuery : IRequest<E.Product>
{
    public Guid Id { get; set; }
}
