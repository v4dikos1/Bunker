using Application.Common.Mappings;
using Application.Packs;
using AutoMapper;

namespace Application.Hobbies
{
    public class Hobby : IMapWith<Domain.Entities.BunkerPlayer.Hobby>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public Guid PackId { get; set; }
        public Pack Pack { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Hobby, Domain.Entities.BunkerPlayer.Hobby>();
        }
    }
}
