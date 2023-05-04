using Application.Common.Exceptions;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace Application.Pictures.Queries.GetPicture
{
    public class GetPictureQueryHandler : IRequestHandler<GetPictureQuery, FileStream>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IFileService _fileService;
        private readonly IValidator<GetPictureQuery> _validator;

        public GetPictureQueryHandler(IBunkerDbContext dbContext, IFileService fileService, IValidator<GetPictureQuery> validator)
        {
            _dbContext = dbContext;
            _fileService = fileService;
            _validator = validator;
        }

        public async Task<FileStream> Handle(GetPictureQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var picture = await _dbContext.Pictures.FindAsync(request.PicturesId);

            if (picture == null)
            {
                throw new NotFoundException(nameof(Picture), request.PicturesId);
            }

            var file = _fileService.GetFile(picture.Path, picture.Id.ToString());

            return file;
        }
    }
}
