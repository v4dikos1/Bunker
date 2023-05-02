using Domain.Bl.Abilities.Interfaces;
using Domain.Entities.BunkerContext;
using Domain.Entities.BunkerPlayer;

namespace Domain.Entities.GameContext
{
    /// <summary>
    /// Сущность игры
    /// </summary>
    public class GameInfo
    {
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Бункер, используемый в игре
        /// </summary>
        public Bunker Bunker { get; set; } = null!;

        /// <summary>
        /// Время, которое предстоит просидеть в бункере
        /// </summary>
        public int Time { get; set; } 

        /// <summary>
        /// Набор карточек
        /// </summary>
        public Pack Pack { get; set; } = null!;

        /// <summary>
        /// Катастрофа
        /// </summary>
        public Disaster Disaster { get; set; } = null!;

        /// <summary>
        /// Список игроков
        /// </summary>
        public IEnumerable<Player> Players { get; set; } = new List<Player>();

        /// <summary>
        /// Список способностей
        /// </summary>
        public List<IAbility> Abilities { get; set; } = new();

    }
}
