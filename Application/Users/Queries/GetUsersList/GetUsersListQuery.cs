using MediatR;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<UsersListVm>
    {
        /// <summary>
        /// Ограничение по количеству возвращаемых пользователей
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Отступ от начала
        /// </summary>
        public int Offset { get; set; }
    }
}
