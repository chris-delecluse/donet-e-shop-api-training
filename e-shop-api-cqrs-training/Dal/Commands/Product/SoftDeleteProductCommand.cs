using MediatR;
using E = Dal.Entities;

namespace Dal.Commands.Product;

public class SoftDeleteProductCommand : IRequest<string>
{
    public Guid Id { get; set; }
}
