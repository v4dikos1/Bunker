using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Pictures.Commands.AddPicture;
using Application.Pictures.Commands.Delete;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly IMediator _mediator;
        private readonly IValidator<UpdateUserCommand> _validator;

        public UpdateUserCommandHandler(IBunkerDbContext dbContext, IPasswordService passwordService, IMediator mediator, IValidator<UpdateUserCommand> validator)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _mediator = mediator;
            _validator = validator;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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

            if (request.Nickname != null)
            {
                user.Nickname = request.Nickname;
            }

            if (request.Email != null)
            {
                if (await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken) != null)
                {
                    throw new AlreadyExistsException(nameof(User), request.Email);
                }

                user.Email = request.Email;
            }


            if (request.Password != null)
            {
                _passwordService.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            if (request.File != null)
            {
                var oldPicture =
                    await _dbContext.Pictures.FirstOrDefaultAsync(p => p.UserId == user.Id, cancellationToken);

                if (oldPicture != null)
                {
                    var deletePictureCommand = new DeletePictureCommand
                    {
                        Id = oldPicture.Id
                    };

                    await _mediator.Send(deletePictureCommand, cancellationToken);
                }

                var addPictureCommand = new AddPictureCommand
                {
                    File = request.File,
                    UserId = user.Id
                };

                var newPicture = await _mediator.Send(addPictureCommand, cancellationToken);

                user.PictureId = newPicture;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
