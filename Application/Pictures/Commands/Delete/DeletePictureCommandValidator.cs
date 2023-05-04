using FluentValidation;

namespace Application.Pictures.Commands.Delete
{
    public class DeletePictureCommandValidator : AbstractValidator<DeletePictureCommand>
    {
        public DeletePictureCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Picture id is required!");
        }
    }
}
