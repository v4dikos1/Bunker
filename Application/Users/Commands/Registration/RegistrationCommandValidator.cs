using FluentValidation;

namespace Application.Users.Commands.Registration
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        public RegistrationCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Invalid Email!");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required!");

            RuleFor(u => u.Nickname)
                .NotEmpty()
                .WithMessage("Nickname is required!");
        }
    }
}
