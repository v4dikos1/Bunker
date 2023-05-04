namespace BunkerApi.Models.User
{
    /// <summary>
    /// Модель данных для обновления пользователя.
    /// </summary>
    public class UserUpdateDto
    {
        /// <summary>
        /// Code обновляемого пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Новый никнейм
        /// </summary>
        public string? Nickname { get; set; }

        /// <summary>
        /// Новая почта
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Новый пароль
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Новая аватарка
        /// </summary>
        public IFormFile? File { get; set; }
    }
}
