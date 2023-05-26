using Dal.Interfaces;
using Dal.Queries.Category;
using Error;
using MediatR;
using E = Dal.Entities;

namespace Business.Queries.Category;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, E.Category?>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdHandler(ICategoryRepository categoryRepository) { _categoryRepository = categoryRepository; }

    public async Task<E.Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.FindAsync(request.Id, cancellationToken) ??
               throw new NotFoundException<E.Category>();
    }
}
