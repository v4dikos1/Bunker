using Domain.Entities.Abilities.AffectBunker;
using Domain.Entities.Abilities.Interfaces;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность игры
    /// </summary>
    public class Game
    {
        public Guid Id { get;} = Guid.NewGuid();

        /// <summary>
        /// Бункер, используемый в игре
        /// </summary>
        public Bunker Bunker { get; set; }

        /// <summary>
        /// Время, которое предстоит просидеть в бункере
        /// </summary>
        public int Time { get; }

        /// <summary>
        /// Набор карточек
        /// </summary>
        public Pack Pack { get; set; }

        /// <summary>
        /// Катастрофа
        /// </summary>
        public Disaster Disaster { get; set; }

        /// <summary>
        /// Список игроков
        /// </summary>
        public IEnumerable<Player> Players { get; set; }

        private List<IAbility> _abilities; 

        public Game(int bunkerSize, int time, int foodCount, Pack pack, IEnumerable<User> users)
        {
            Pack = pack;
            Time = time;

            _abilities = GenerateAbilities();

            Bunker = GenerateBunker(pack, bunkerSize, foodCount);
            Disaster = GenerateDisaster(pack);
            Players = GeneratePlayers(pack, users);
        }

        /// <summary>
        /// Исключение игрока
        /// </summary>
        /// <param name="id">Id исключаемого игрока</param>
        /// <returns>Возвращает исключенного игрока</returns>
        public Player KickPlayer(Guid id)
        {
            var player = Players.First(p => p.UserId == id);
            player.IsKicked = true;

            return player;
        }

        public void UseAbility(Player player)

        /// <summary>
        /// Генерация бункера
        /// </summary>
        /// <param name="pack">Пак карточек</param>
        /// <param name="bunkerSize">Вместимость</param>
        /// <param name="foodCount">Количество еды</param>
        /// <returns>Возвращает бункер</returns>
        public Bunker GenerateBunker(Pack pack, int bunkerSize, int foodCount)
        {
            Random rnd = new Random();

            var buildings = pack.Items.Where(i => i.Type == BunkerItemType.Building).ToList();
            var buffs = pack.Items.Where(i => i.Type == BunkerItemType.Buff).ToList();
            var debuffs = pack.Items.Where(i => i.Type == BunkerItemType.Debuff).ToList();

            var building = buildings.ElementAt(rnd.Next(buildings.Count));
            var buff = buffs.ElementAt(rnd.Next(buffs.Count));
            var debuff = debuffs.ElementAt(rnd.Next(debuffs.Count));

            return new Bunker(bunkerSize, foodCount, building, buff, debuff);
        }

        /// <summary>
        /// Генерация списка игроков
        /// </summary>
        /// <param name="pack">Пак карточек</param>
        /// <param name="users">Пользователи</param>
        /// <returns>Возвращает список игроков</returns>
        private List<Player> GeneratePlayers(Pack pack, IEnumerable<User> users)
        {
            var players = new List<Player>();

            Random rnd = new Random();

            foreach (var user in users)
            {
                Players.Append(new Player
                {
                    UserId = user.Id,
                    Age = rnd.Next(14, 120),
                    Gender = (Gender)rnd.Next(0, 1),
                    Orientation = (Orientation)rnd.Next(0, 1),
                    Hobby = pack.Hobbies.ElementAt(rnd.Next(pack.Hobbies.Count())),
                    Fact = pack.Facts.ElementAt(pack.Facts.Count()),
                    Health = pack.Healths.ElementAt(pack.Healths.Count()),
                    Luggage = pack.LuggageList.ElementAt(pack.LuggageList.Count()),
                    Profession = pack.Professions.ElementAt(pack.Professions.Count()),
                    Abilities = new List<IAbility>(),
                    IsKicked = false
                });
            }

            return players;
        }

        /// <summary>
        /// Генерация катастрофы
        /// </summary>
        /// <param name="pack">Пак</param>
        /// <returns>Возращает катастрофу</returns>
        private Disaster GenerateDisaster(Pack pack)
        {
            Random rnd = new Random();
            return pack.Disasters.ElementAt(rnd.Next(pack.Disasters.Count()));
        }

        /// <summary>
        /// Генерация списка способностей
        /// </summary>
        /// <returns>Возвращает список униканльных способностей</returns>
        private List<IAbility> GenerateAbilities()
        {
            var abilities = new List<IAbility>
            {
                new GenerateNewBunkerAbility(),

            };

            return abilities;
        }
    }
}
