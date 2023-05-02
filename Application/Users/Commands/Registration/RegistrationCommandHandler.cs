using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Pictures.Commands.AddPicture;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand>
    {
        private readonly IPasswordService _passwordService;
        private readonly IBunkerDbContext _dbContext;
        private readonly IMediator _mediator;

        public RegistrationCommandHandler(IPasswordService passwordService, IBunkerDbContext dbContext, IMediator mediator)
        {
            _passwordService = passwordService;
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {

            if (await _dbContext.Users.FirstOrDefaultAsync(u => u.Email.Equals(request.Email), cancellationToken) != null)
            {
                throw new AlreadyExistsException(nameof(User), request.Email);
            }


            if (await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname.Equals(request.Nickname), cancellationToken) != null)
            {
                throw new AlreadyExistsException(nameof(User), request.Nickname);
            }

            _passwordService.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Nickname = request.Nickname,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var pictureId = await _mediator.Send(new AddPictureCommand { UserId = user.Id, File = request.File }, cancellationToken);

            user.PictureId = pictureId;

            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
