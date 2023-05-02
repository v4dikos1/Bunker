using Application.Common.Mappings;
using Application.Users.Commands.Registration;
using AutoMapper;

namespace BunkerApi.Models.User
{
    public class UserRegistrationDto : IMapWith<RegistrationCommand>
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
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Аватар
        /// </summary>
        public IFormFile File { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRegistrationDto, RegistrationCommand>();
        }
    }
}
