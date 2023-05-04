using Application.Common.Exceptions;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pictures.Commands.Delete
{
    public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IValidator<DeletePictureCommand> _validator;

        public DeletePictureCommandHandler(IBunkerDbContext dbContext, IFileService fileService, IValidator<DeletePictureCommand> validator)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _validator = validator;
        }

        public async Task Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var picture = await _dbContext.Pictures.FindAsync(request.Id, cancellationToken);

            if (picture == null)
            {
                throw new NotFoundException(nameof(Picture), request.Id);
            }

            if (_fileService.DeleteFile(picture.Path))
            {
                _dbContext.Pictures.Remove(picture);

                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
