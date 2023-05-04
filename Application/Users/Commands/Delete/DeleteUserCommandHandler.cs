using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Pictures.Commands.Delete;
using FluentValidation;
using MediatR;

namespace Application.Users.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IValidator<DeleteUserCommand> _validator;

        public DeleteUserCommandHandler(IBunkerDbContext dbContext, IMediator mediator, IValidator<DeleteUserCommand> validator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
            _validator = validator;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _dbContext.Users.FindAsync(request.UserId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            if (user.Id != request.CurrentUserId)
            {
                throw new UserOperationCancelledException();
            }

            if (user.PictureId != null)
            {
                var command = new DeletePictureCommand
                {
                    Id = (Guid)user.PictureId
                };

                await _mediator.Send(command, cancellationToken);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
