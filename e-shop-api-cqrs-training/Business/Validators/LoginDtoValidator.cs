using Business.Dtos.Auth;
using FluentValidation;

namespace Business.Validators;

public class LoginDtoValidator : AbstractValidator<SignInRequestDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Invalid Credentials");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Invalid Credentials");
    }
}
