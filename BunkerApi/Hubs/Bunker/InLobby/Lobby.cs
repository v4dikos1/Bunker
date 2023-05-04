namespace BunkerApi.Hubs.Bunker.InLobby
{
    public class Lobby
    {
        public string Code { get; }

        public Guid PackId { get; set; }
        public int PlayersCount { get; set; }
        public Guid HostId { get; set; }

        public List<LobbyUser> Users { get; set; }

        public Lobby(Guid hostId, Guid packId, int playersCount, string code)
        {
            Users = new List<LobbyUser>();
            HostId = hostId;
            PackId = packId;
            PlayersCount = playersCount;
            Code = code;
        }

        public bool ConnectUser(Guid userId, string connectionId)
        {
            var userAlreadyExists = Users.FirstOrDefault(u => u.Id == userId);
            if (userAlreadyExists != null && Users.Count <= PlayersCount)
            {
                return false;
            }

            var user = new LobbyUser(userId, connectionId, Code);
            Users.Add(user);

            return true;
        }

        public bool DisconnectUser(Guid userId)
        {
            var userExists = Users.FirstOrDefault(u => u.Id == userId);
            if (userExists != null)
            {
                Users.Remove(userExists);

                return true;
            }

            return false;
        }
    }
}
