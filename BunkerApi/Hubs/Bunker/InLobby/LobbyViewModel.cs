using Application.Common.Mappings;
using Application.Packs;
using Application.Users;
using AutoMapper;

namespace BunkerApi.Hubs.Bunker.InLobby
{
    public class LobbyViewModel : IMapWith<Lobby>
    {
        public Guid Id { get; set; } 
        public string Code { get; set; } = string.Empty;

        public Pack Pack { get; set; } = null!;
        public int PlayersCount { get; set; }
        public Guid HostId { get; set; }

        public List<User> Users { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Lobby, LobbyViewModel>();
        }
    }
}
