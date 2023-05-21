using MediatR;
using E = Dal.Entities;
namespace Dal.Queries.Category;

public class GetCategoryByIdQuery : IRequest<E.Category>
{
    public Guid Id { get; set; }
}
