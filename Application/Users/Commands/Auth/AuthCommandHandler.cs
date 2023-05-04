using Application.Common.Exceptions;
using Application.Common.Interfaces;
using MediatR;
using System.Security.Claims;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Commands.Auth
{
    public class AuthCommandHandler : IRequestHandler<AuthCommand, string>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IValidator<AuthCommand> _validator;

        public AuthCommandHandler(IBunkerDbContext dbContext, IPasswordService passwordService, ITokenService tokenService, IValidator<AuthCommand> validator)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _validator = validator;
        }

        public async Task<string> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var userByEmail =
                await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Login, cancellationToken);

            var userByUsername =
                await _dbContext.Users.FirstOrDefaultAsync(u => u.Nickname == request.Login, cancellationToken);

            if (userByEmail == null && userByUsername == null)
            {
                throw new NotFoundException(nameof(User), request.Login);
            }

            var user = userByUsername ?? userByEmail;

            if (!_passwordService.VerifyPasswordHash(request.Password, user!.PasswordHash, user.PasswordSalt))
            {
                throw new InvalidLoginOrPasswordException();
            }

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Nickname)
            };

            var token = _tokenService.CreateToken(user, claims);

            return token;
        }
    }
}
