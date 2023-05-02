using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Professions
{
    public class Profession : IMapWith<Domain.Entities.BunkerPlayer.Profession>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId {get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Profession, Domain.Entities.BunkerPlayer.Profession>();
        }
    }
}
