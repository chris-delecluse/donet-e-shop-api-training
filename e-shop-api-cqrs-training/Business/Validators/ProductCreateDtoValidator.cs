using Business.Dtos.Product;
using FluentValidation;

namespace Business.Validators;

public class ProductCreateDtoValidator: AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .NotEmpty();
    }
}
