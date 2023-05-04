using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest
    {
        /// <summary>
        /// Code обновляемого пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Текущий пользователь (тот, который пытается обновить пользователя)
        /// </summary>
        public Guid CurrentUserId { get; set; }

        public string? Nickname { get; set; }

        public string? Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string? Password { get; set; }

        public IFormFile? File { get; set; }
    }
}
