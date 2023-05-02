using Domain.Entities.Bunker;

namespace Domain.Bl.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность, вляющая на бункер
    /// </summary>
    public interface IBunkerAffectAbility : IAbility
    {
        Bunker Use(Bunker bunker);
    }
}
