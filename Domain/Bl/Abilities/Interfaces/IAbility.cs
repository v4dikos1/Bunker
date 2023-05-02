namespace Domain.Bl.Abilities.Interfaces
{
    /// <summary>
    /// Уникальная способность
    /// </summary>
    public interface IAbility
    {
        public int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
