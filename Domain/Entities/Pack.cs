namespace Domain.Entities
{
    /// <summary>
    /// Сущность пака карточек
    /// </summary>
    public class Pack
    {
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Название пака
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Набор хобби
        /// </summary>
        public IEnumerable<Hobby> Hobbies { get; set; } = new List<Hobby>();

        /// <summary>
        /// Набор здоровья
        /// </summary>
        public IEnumerable<Health> Healths { get; set; } = new List<Health>();

        /// <summary>
        /// Набор багажей
        /// </summary>
        public IEnumerable<Luggage> LuggageList { get; set; } = new List<Luggage>();

        /// <summary>
        /// Набор фактов
        /// </summary>
        public IEnumerable<Fact> Facts { get; set; } = new List<Fact>();

        /// <summary>
        /// Набор профессий
        /// </summary>
        public IEnumerable<Profession> Professions { get; set; } = new List<Profession>();

        /// <summary>
        /// Набор катастроф
        /// </summary>
        public IEnumerable<Disaster> Disasters { get; set; } = new List<Disaster>();

        /// <summary>
        /// Набор составляющих бункера
        /// </summary>
        public IEnumerable<BunkerItem> Items { get; set; } = new List<BunkerItem>();

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Pack pack) return Id == pack.Id;
            return false;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
