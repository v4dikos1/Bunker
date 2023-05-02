using Domain.Entities.BunkerPlayer;

namespace Domain.Bl.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность, влияющая на игрока
    /// </summary>
    public interface IPlayerAffectAbility : IAbility
    {
        Player Use(Player player);
    }
}
