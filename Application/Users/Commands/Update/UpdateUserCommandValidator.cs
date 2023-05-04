using FluentValidation;

namespace Application.Users.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.CurrentUserId).NotEmpty().WithMessage("CurrentUserId is required!");
            RuleFor(c => c.UserId).NotEmpty().WithMessage("UserId is required!");
        }
    }
}
