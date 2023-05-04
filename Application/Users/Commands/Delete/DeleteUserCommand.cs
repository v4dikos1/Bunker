using MediatR;

namespace Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid CurrentUserId { get; set; }
    }
}
