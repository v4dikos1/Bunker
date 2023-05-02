using Application.Common.Interfaces;
using MediatR;

namespace Application.Pictures.Commands.AddPicture
{
    public class AddPictureCommandHandler : IRequestHandler<AddPictureCommand, Guid>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IFileService _fileService;

        public AddPictureCommandHandler(IBunkerDbContext dbContext, IFileService fileService)
        {
            _dbContext = dbContext;
            _fileService = fileService;
        }

        public async Task<Guid> Handle(AddPictureCommand request, CancellationToken cancellationToken)
        {
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
