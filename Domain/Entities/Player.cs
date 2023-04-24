using Domain.Entities.Abilities.Interfaces;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность игрока
    /// </summary>
    public class Player
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// Возраст игрока
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Сексуальная ориентация
        /// </summary>
        public Orientation Orientation { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Хобби
        /// </summary>
        public Hobby Hobby { get; set; } = null!;

        /// <summary>
        /// Здоровье
        /// </summary>
        public Health Health { get; set; } = null!;

        /// <summary>
        /// Факт об игроке
        /// </summary>
        public Fact Fact { get; set; } = null!;

        /// <summary>
        /// Багаж
        /// </summary>
        public Luggage Luggage { get; set; } = null!;

        /// <summary>
        /// Профессия
        /// </summary>
        public Profession Profession { get; set; } = null!;

        /// <summary>
        /// Исключен ли игрок из игры
        /// </summary>
        public bool IsKicked { get; set; } = false;

        /// <summary>
        /// Набор уникальных спобностей
        /// </summary>
        public IEnumerable<IAbility> Abilities { get; set; } = new List<IAbility>();

    }
}
