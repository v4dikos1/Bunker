namespace Domain.Entities
{
    /// <summary>
    /// Составляющая бункера
    /// </summary>
    public class BunkerItem
    {
        public string Name { get; set; } = string.Empty;
        public BunkerItemType Type { get; set; }
    }
}
