using Dal.Interfaces;
using Dal.Queries.Category;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Category;

/// <summary>
/// Handler for retrieving a category by id.
/// </summary>
public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, E.Category?>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCategoryByIdHandler"/> class.
    /// </summary>
    /// <param name="categoryRepository">The category repository.</param>
    public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<E.Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.FindAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Category>();
    }
}
