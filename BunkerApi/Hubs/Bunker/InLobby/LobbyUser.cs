namespace BunkerApi.Hubs.Bunker.InLobby
{
    public class LobbyUser
    {
        public Guid Id { get; set; }
        public string LobbyCode { get; set; }

        public LobbyConnection Connection { get; }

        public LobbyUser(Guid userId, string connectionId, string lobbyCode)
        {
            Id = userId;
            Connection = new LobbyConnection { ConnectionId = connectionId };
            LobbyCode = lobbyCode;
        }
    }
}
