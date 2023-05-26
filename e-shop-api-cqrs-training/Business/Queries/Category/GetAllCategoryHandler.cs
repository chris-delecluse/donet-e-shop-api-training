using Dal.Interfaces;
using Dal.Queries.Category;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Category;

/// <summary>
/// Handler for retrieving all categories.
/// </summary>
public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<E.Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCategoryHandler"/> class.
    /// </summary>
    /// <param name="categoryRepository">The category repository.</param>
    public GetAllCategoryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<E.Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.FindAsync(cancellationToken);
    }
}
