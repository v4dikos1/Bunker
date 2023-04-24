namespace Domain.Entities
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
    }
}
