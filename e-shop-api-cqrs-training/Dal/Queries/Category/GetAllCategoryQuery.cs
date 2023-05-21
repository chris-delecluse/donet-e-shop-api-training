using MediatR;
using E = Dal.Entities;

namespace Dal.Queries.Category;

public class GetAllCategoryQuery : IRequest<IEnumerable<E.Category>> { }
