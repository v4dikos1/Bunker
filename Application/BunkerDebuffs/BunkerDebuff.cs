using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.BunkerDebuffs
{
    public class BunkerDebuff : IMapWith<Domain.Entities.BunkerContext.BunkerDebuff>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BunkerDebuff, Domain.Entities.BunkerContext.BunkerDebuff>();
        }
    }
}
