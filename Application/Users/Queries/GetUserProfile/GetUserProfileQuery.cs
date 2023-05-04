using MediatR;

namespace Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQuery : IRequest<UserProfileVm>
    {
        public Guid Id { get; set; }
    }
}
