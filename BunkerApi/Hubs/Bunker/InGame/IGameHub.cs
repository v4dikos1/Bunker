using Application.Disasters;
using BunkerApi.Hubs.Bunker.InLobby;
using Domain.Entities;
using Domain.Entities.BunkerPlayer;

namespace BunkerApi.Hubs.Bunker.InGame
{
    public interface IGameHub
    {
        Task GameStarted(GameDto game);
        Task UserGenerated(User user);
        Task LobbyCreated(LobbyViewModel lobby);
        Task UserConnectedToLobby(LobbyViewModel lobby);
    }
}
