using Domain.Bl.Abilities.Interfaces;
using Domain.Entities.BunkerPlayer;
using Domain.Entities.GameContext;

namespace BunkerApi.Hubs.Bunker.InGame
{
    public class GameDto
    {
        public List<Player> Players { get; set; } = null!;
        public Domain.Entities.BunkerContext.Bunker Bunker { get; set; } = null!;
        public Disaster Disaster { get; set; } = null!;
        public Guid PackId { get; set; }
        public int Time { get; set; }
    }
}
