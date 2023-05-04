using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListVm>
    {
        private readonly IBunkerDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<GetUsersListQuery> _validator;

        public GetUsersListQueryHandler(IBunkerDbContext dbContext, IMapper mapper, IValidator<GetUsersListQuery> validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UsersListVm> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var users = await _dbContext.Users
                .Skip(request.Offset)
                .Take(request.Limit)
                .ProjectTo<UserProfileVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UsersListVm { Users = users };
        }
    }
}
