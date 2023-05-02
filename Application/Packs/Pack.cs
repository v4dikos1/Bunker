using Application.BunkerBuffs;
using Application.BunkerBuildings;
using Application.BunkerDebuffs;
using Application.Common.Mappings;
using Application.Disasters;
using Application.Facts;
using Application.Healths;
using Application.Hobbies;
using Application.Luggages;
using Application.Professions;
using AutoMapper;

namespace Application.Packs
{
    /// <summary>
    /// Пак карточек
    /// </summary>
    public class Pack : IMapWith<Domain.Entities.GameContext.Pack>
    {
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Название пака
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Набор профессий
        /// </summary>
        public List<Profession> Professions { get; set; } = new ();

        /// <summary>
        /// Набор багажей
        /// </summary>
        public List<Luggage> Luggages { get; set; } = new();

        /// <summary>
        /// Набор катастроф
        /// </summary>
        public List<Disaster> Disasters { get; set; } = new();

        /// <summary>
        /// Набор здоровья
        /// </summary>
        public List<Health> Healths { get; set; } = new();

        /// <summary>
        /// Набор хобби
        /// </summary>
        public List<Hobby> Hobbies { get; set; } = new();

        /// <summary>
        /// Набор фактов
        /// </summary>
        public List<Fact> Facts { get; set; } = new();

        /// <summary>
        /// Набор построек в бункере
        /// </summary>
        public List<BunkerBuilding> BunkerBuildings { get; set; } = new();

        /// <summary>
        /// Набор баффов бункера
        /// </summary>
        public List<BunkerBuff> BunkerBuffs { get; set; } = new();

        /// <summary>
        /// Набор дебаффов бункера
        /// </summary>
        public List<BunkerDebuff> BunkerDebuffs { get; set; } = new();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pack, Domain.Entities.GameContext.Pack>();
        }
    }
}
