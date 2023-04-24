namespace Domain.Entities.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность, влияющая на ход игры
    /// </summary>
    public interface IGameAffectAbility : IAbility
    {
        Game Use(Game game);
    }
}
