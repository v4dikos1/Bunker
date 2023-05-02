using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Luggages
{
    public class Luggage : IMapWith<Domain.Entities.BunkerPlayer.Luggage>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Luggage, Domain.Entities.BunkerPlayer.Luggage>();
        }
    }
}
