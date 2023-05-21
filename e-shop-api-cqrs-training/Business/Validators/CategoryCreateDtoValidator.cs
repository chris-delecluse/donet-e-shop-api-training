using Business.Dtos.Category;
using FluentValidation;

namespace Business.Validators;

public class CategoryCreateDtoValidator: AbstractValidator<CategoryCreateDto>
{
    public CategoryCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Please enter the name of the \"category you\" would like to create");
    }
}
