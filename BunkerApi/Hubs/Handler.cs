using Domain.Bl;

namespace BunkerApi.Hubs
{
    public class Handler
    {
        public string LobbyCode { get; set; }
        public GameHandler GameHandler { get; set; }

        public Handler(GameHandler gameHandler, string lobbyCode)
        {
            GameHandler = gameHandler;
            LobbyCode = lobbyCode;
        }
    }
}
