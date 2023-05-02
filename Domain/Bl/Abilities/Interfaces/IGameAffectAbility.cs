using Domain.Entities.GameContext;

namespace Domain.Bl.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность, влияющая на ход игры
    /// </summary>
    public interface IGameAffectAbility : IAbility
    {
        GameInfo Use(GameInfo game);
    }
}
