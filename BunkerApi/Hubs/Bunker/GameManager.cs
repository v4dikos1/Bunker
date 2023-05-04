using Application.Common.Interfaces;
using AutoMapper;
using BunkerApi.Hubs.Bunker.InLobby;
using Domain.Bl;
using Domain.Entities;

namespace BunkerApi.Hubs.Bunker
{
    public class GameManager
    {
        public List<Lobby> Lobbies { get; set; } = new List<Lobby>();
        public List<LobbyUser> UsersInLobby { get; set; } = new List<LobbyUser>();
        public List<Handler> Handlers { get; set; } = new List<Handler>();

        private const string CodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const int CodeLength = 6;

        private readonly IMapper _mapper;
        private readonly IBunkerDbContext _dbContext;

        public GameManager(IMapper mapper, IBunkerDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Lobby CreateLobby(Guid hostId, Guid packId, int playersCount, string connectionId)
        {
            Random rnd = new Random();

            var code = new string(Enumerable.Repeat(CodeChars, CodeLength)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            Lobby lobby = new Lobby(hostId, packId, playersCount, code);
            Lobbies.Add(lobby);

            ConnectUserToLobby(hostId, connectionId, lobby.Code);

            return lobby;
        }

        public bool ConnectUserToLobby(Guid userId, string connectionId, string lobbyCode)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Code == lobbyCode);
            if (lobby == null)
            {
                return false;
            }

            if (UsersInLobby.Any(u => u.Id == userId))
            {
                return false;
            }

            var result = lobby.ConnectUser(userId, connectionId);

            if (result == true)
            {
                UsersInLobby.Add(lobby.Users.First(u => u.Id == userId));
                return true;
            }

            return false;
        }

        public bool DisconnectUser(Guid userId, string connectionId)
        {
            var user = UsersInLobby.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                var lobby = Lobbies.First(l => l.Code == user.LobbyCode);
                lobby.DisconnectUser(user.Id);
                UsersInLobby.Remove(user);

                return true;
            }

            return false;
        }

        public bool RemoveLobby(string lobbyCode)
        {
            var lobbyExists = Lobbies.FirstOrDefault(l => l.Code == lobbyCode);
            if (lobbyExists != null)
            {
                foreach (var user in lobbyExists.Users)
                {
                    DisconnectUser(user.Id, user.Connection.ConnectionId);
                }
                Lobbies.Remove(lobbyExists);

                return true;
            }

            return false;
        }

        public async void StartGame(string lobbyCode)
        {
            var lobby = Lobbies.FirstOrDefault(l => l.Code == lobbyCode);
            if (lobby != null)
            {
                var users = new List<Domain.Entities.User>();

                foreach (var lobbyUser in lobby.Users)
                {
                    var user = await _dbContext.Users.FindAsync(lobbyUser.Id);

                    if (user != null) users.Add(_mapper.Map<User>(user));
                }

                var pack = await _dbContext.Packs.FindAsync(lobby.PackId);

                var gameHandler = new GameHandler(
                    lobby.PlayersCount,
                    _mapper.Map<Domain.Entities.GameContext.Pack>(pack),
                    users
                    );

                Handlers.Add(new Handler(gameHandler, lobby.Code));
            }
        }
    }
}
