using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Category;

public class GetCategoryByNameQuery : IRequest<E.Category>
{
    public string Name { get; set; }
}
