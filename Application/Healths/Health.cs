using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Healths
{
    public class Health : IMapWith<Domain.Entities.BunkerPlayer.Health>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId {get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Health, Domain.Entities.BunkerPlayer.Health>();
        }
    }
}
