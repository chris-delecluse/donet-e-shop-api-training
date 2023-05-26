using Dal.Interfaces;
using Dal.Queries.Category;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Category;

/// <summary>
/// Handler for retrieving a category by name.
/// </summary>
public class GetCategoryByNameHandler : IRequestHandler<GetCategoryByNameQuery, E.Category?>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoryByNameHandler"/> class.
    /// </summary>
    /// <param name="categoryRepository">The category repository.</param>
    public GetCategoryByNameHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<E.Category?> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.FindAsync(request.Name, cancellationToken);
    }
}
