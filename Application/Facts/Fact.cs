using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Facts
{
    public class Fact : IMapWith<Domain.Entities.BunkerPlayer.Fact>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Fact, Domain.Entities.BunkerPlayer.Fact>();
        }
    }
}
