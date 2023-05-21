using Dal.Interfaces;
using Dal.Queries.Category;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Category;

public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<E.Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryHandler(ICategoryRepository categoryRepository) { _categoryRepository = categoryRepository; }

    public async Task<IEnumerable<E.Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.FindAsync(cancellationToken);
    }
}
