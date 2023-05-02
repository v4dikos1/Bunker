using Application.Common.Mappings;
using Application.Packs;
using Application.Pictures;
using AutoMapper;

namespace Application.Users
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User : IMapWith<Domain.Entities.User>
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ник
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt {get; set; } = null!;

        /// <summary>
        /// Аватарка
        /// </summary>
        public Guid? PictureId { get; set; }
        public Picture? Picture { get; set; }

        /// <summary>
        /// Созданные паки
        /// </summary>
        public List<Pack> Packs { get; set; } = new List<Pack>();


        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, Domain.Entities.User>();
        }
    }
}
