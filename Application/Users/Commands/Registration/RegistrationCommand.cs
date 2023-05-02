using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Users.Commands.Registration
{
    public class RegistrationCommand : IRequest
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; } = string.Empty;


        /// <summary>
        /// Аватар
        /// </summary>
        public IFormFile File { get; set; } = null!;
    }
}
