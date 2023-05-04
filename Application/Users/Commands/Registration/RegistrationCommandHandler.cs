using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Pictures.Commands.AddPicture;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, UserProfileVm>
    {
        private readonly IPasswordService _passwordService;
        private readonly IBunkerDbContext _dbContext;
        private readonly IMediator _mediator;
        private readonly IValidator<RegistrationCommand> _validator;
        private readonly IMapper _mapper;

        public RegistrationCommandHandler(IPasswordService passwordService, IBunkerDbContext dbContext, IMediator mediator,
            IValidator<RegistrationCommand> validator, IMapper mapper)
        {
            _passwordService = passwordService;
            _dbContext = dbContext;
            _mediator = mediator;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UserProfileVm> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

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

            return _mapper.Map<UserProfileVm>(user);
        }
    }
}
