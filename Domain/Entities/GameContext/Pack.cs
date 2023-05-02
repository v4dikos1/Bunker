using Domain.Entities.BunkerContext;
using Domain.Entities.BunkerPlayer;

namespace Domain.Entities.GameContext
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
        public IEnumerable<Hobby> Hobbies { get; set; } = null!;

        /// <summary>
        /// Набор здоровья
        /// </summary>
        public IEnumerable<Health> Healths { get; set; } = null!;

        /// <summary>
        /// Набор багажей
        /// </summary>
        public IEnumerable<Luggage> LuggageList { get; set; } = null!;

        /// <summary>
        /// Набор фактов
        /// </summary>
        public IEnumerable<Fact> Facts { get; set; } = null!;

        /// <summary>
        /// Набор профессий
        /// </summary>
        public IEnumerable<Profession> Professions { get; set; } = null!;

        /// <summary>
        /// Набор катастроф
        /// </summary>
        public IEnumerable<Disaster> Disasters { get; set; } = null!;

        /// <summary>
        /// Набор строений в бункере
        /// </summary>
        public IEnumerable<BunkerBuilding> Buildings { get; set; } = null!;

        /// <summary>
        /// Набор баффов
        /// </summary>
        public IEnumerable<BunkerBuff> Buffs { get; set; } = null!;

        /// <summary>
        /// Набор дебаффов
        /// </summary>
        public IEnumerable<BunkerDebuff> Debuffs { get; set; } = null!;

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
