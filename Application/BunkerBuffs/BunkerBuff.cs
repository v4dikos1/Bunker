using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.BunkerBuffs
{
    public class BunkerBuff : IMapWith<Domain.Entities.BunkerContext.BunkerBuff>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BunkerBuff, Domain.Entities.BunkerContext.BunkerBuff>();
        }
    }
}
