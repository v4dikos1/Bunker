using Application.Common.Mappings;
using Application.Users.Commands.Auth;
using AutoMapper;

namespace BunkerApi.Models.User
{
    public class UserAuthDto : IMapWith<AuthCommand>
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Юзернейм или почта
        /// </summary>
        public string Login { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserAuthDto, AuthCommand>();
        }
    }
}
