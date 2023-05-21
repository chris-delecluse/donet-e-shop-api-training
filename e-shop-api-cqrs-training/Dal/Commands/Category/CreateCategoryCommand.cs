using MediatR;
using E = Dal.Entities;

namespace Dal.Commands.Category;

public class CreateCategoryCommand : IRequest<E.Category>
{
    public string Name { get; set; }
}
