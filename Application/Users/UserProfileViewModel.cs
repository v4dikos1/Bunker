using Application.Common.Mappings;
using AutoMapper;

namespace Application.Users
{
    public class UserProfileVm : IMapWith<User>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Аватарка
        /// </summary>
        public Guid? PictureId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserProfileVm>();
        }
    }
}
