using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Disasters
{
    public class Disaster : IMapWith<Domain.Entities.GameContext.Disaster>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Disaster, Domain.Entities.GameContext.Disaster>();
        }
    }
}
