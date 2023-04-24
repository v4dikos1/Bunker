namespace Domain.Entities.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность, влияющая на игрока
    /// </summary>
    public interface IPlayerAffectAbility : IAbility
    {
        Player Use(Player player);
    }
}
