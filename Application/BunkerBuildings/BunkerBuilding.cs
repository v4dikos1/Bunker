using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.BunkerBuildings
{
    public class BunkerBuilding : IMapWith<Domain.Entities.BunkerContext.BunkerBuilding>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BunkerBuilding, Domain.Entities.BunkerContext.BunkerBuilding>();
        }
    }
}
