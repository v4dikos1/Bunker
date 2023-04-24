using Domain.Entities.Abilities.Interfaces;

namespace Domain.Entities.Abilities.AffectBunker
{
    public class GenerateNewBunkerAbility : IGameAffectAbility
    {
        public int Id { get; } = 1;

        public string Name { get; } = "Generate a new Bunker";

        public string Description { get; } =
            "Generate a new bunker. The amount of food in the bunker will be changed. Structures and breakdowns in the bunker will also be changed.";

        public Game Use(Game game)
        {
            game.Bunker = game.GenerateBunker(game.Pack, game.Bunker.Size, game.Bunker.FoodCount);

            return game;
        }
    }
}
