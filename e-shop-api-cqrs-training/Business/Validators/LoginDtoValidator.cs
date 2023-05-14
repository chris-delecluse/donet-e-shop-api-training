using Business.Dtos.Auth;
using FluentValidation;

namespace Business.Validators;

public class LoginDtoValidator : AbstractValidator<SignInRequestDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$")
            .WithMessage(
                "The password must have at least one digit, one lowercase letter, one uppercase letter, and be at least 6 characters long."
            );
    }
}
