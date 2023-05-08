using Business.Dtos.User;
using FluentValidation;

namespace Business.Validator;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(dto => dto.FirstName)
            .Length(3, 25)
            .NotEmpty();

        RuleFor(dto => dto.LastName)
            .Length(3, 25)
            .NotEmpty();

        RuleFor(dto => dto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(dto => dto.Password)
            .NotEmpty()
            .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$")
            .WithMessage(
                "The password must have at least one digit, one lowercase letter, one uppercase letter, and be at least 6 characters long."
            );
    }
}
