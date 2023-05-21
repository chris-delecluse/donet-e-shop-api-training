using Dal.Commands.Category;
using Dal.Interfaces;
using MediatR;
using E = Dal.Entities;

namespace Business.Commands.Category;

/// <summary>
/// Handler for creating a category.
/// </summary>
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, E.Category>
{
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCategoryCommandHandler"/> class.
    /// </summary>
    /// <param name="categoryRepository">The category repository.</param>
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<E.Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        E.Category category = new E.Category() { Name = request.Name };

        return await _categoryRepository.AddAsync(category, cancellationToken);
    }
}
