using MediatR;
using E = Dal.Entities;

namespace Dal.Commands.Product;

public class CreateProductCommand : IRequest<E.Product>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; init; }
}
