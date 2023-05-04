using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users;
using AutoMapper;
using BunkerApi.Exceptions;
using BunkerApi.Hubs.Bunker.InLobby;
using Microsoft.AspNetCore.SignalR;

namespace BunkerApi.Hubs.Bunker.InGame
{
    public class GameHub : Hub<IGameHub>
    {
        private readonly GameManager _gameManager;
        private readonly IMapper _mapper;
        private readonly IBunkerDbContext _dbContext;

        public GameHub(GameManager gameManager, IMapper mapper, IBunkerDbContext dbContext)
        {
            _gameManager = gameManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public override Task OnConnectedAsync()
        {

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task CreateLobby(Guid hostId, Guid packId, int playersCount)
        {
            var lobby = _gameManager.CreateLobby(hostId, packId, playersCount, Context.ConnectionId);
            await Clients.Caller.LobbyCreated(_mapper.Map<LobbyViewModel>(lobby));
        }

        public async Task ConnectToLobby(string code)
        {
            var connectionId = Context.ConnectionId;
            var userId = Guid.Parse(Context.UserIdentifier);
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), userId);
            }

            var result = _gameManager.ConnectUserToLobby(userId, connectionId, code);
            if (result == true)
            {
                var lobby = _gameManager.Lobbies.First(l => l.Code == code);
                await Clients.Caller.UserConnectedToLobby(_mapper.Map<LobbyViewModel>(lobby));
            }
            else
            {
                throw new NotFoundException(nameof(Lobby), code);
            }
        }

        public async Task StartGame(string lobbyCode)
        {
            var connectionId = Context.ConnectionId;
            var userId = Guid.Parse(Context.UserIdentifier);

            var lobby = _gameManager.Lobbies.First(l => l.Code == lobbyCode);
            if (lobby.HostId != userId)
            {
                throw new IllegalOperationException();
            }

            var clients = lobby.Users.ConvertAll(u => u.Connection.ConnectionId);
            _gameManager.StartGame(lobbyCode);

            var handler = _gameManager.Handlers.First(h => h.LobbyCode == lobbyCode).GameHandler;

            var game = new GameDto
            {
                Time = handler.GameInfo.Time,
                Bunker = handler.GameInfo.Bunker,
                Disaster = handler.GameInfo.Disaster,
                PackId = handler.GameInfo.Pack.Id,
                Players = handler.GameInfo.Players.ToList()
            };

            await Clients.Clients(clients).GameStarted(game);
        }
    }
}
