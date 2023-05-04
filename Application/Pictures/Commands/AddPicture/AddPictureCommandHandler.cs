using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pictures.Commands.AddPicture
{
    public class AddPictureCommandHandler : IRequestHandler<AddPictureCommand, Guid>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IValidator<AddPictureCommand> _validator;

        public AddPictureCommandHandler(IBunkerDbContext dbContext, IFileService fileService, IValidator<AddPictureCommand> validator)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _validator = validator;
        }

        public async Task<Guid> Handle(AddPictureCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var picture = new Picture
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(),
            };

            picture.Path = await _fileService.SaveFileAsync(picture.UserId.ToString(), request.File, picture.Id.ToString(),
                cancellationToken);

            await _dbContext.Pictures.AddAsync(picture, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return picture.Id;
        }
    }
}
