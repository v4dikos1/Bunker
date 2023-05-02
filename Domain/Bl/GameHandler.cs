using Domain.Bl.Abilities.AffectBunker;
using Domain.Bl.Abilities.Interfaces;
using Domain.Entities.BunkerContext;
using Domain.Entities.BunkerPlayer;
using Domain.Entities.GameContext;
using Domain.Entities;

namespace Domain.Bl
{
    public class GameHandler
    {
        private const int MinDays = 80;
        private const int MaxDays = 666;

        private const int MinPlayerAge = 14;
        private const int MaxPlayerAge = 121;

        private readonly GameInfo _gameInfo;
        private readonly Pack _pack; 

        public GameHandler(int playerCount, Pack pack, IEnumerable<User> users)
        {
            Random rnd = new Random();

            _pack = pack;

            _gameInfo = new GameInfo
            {
                Time = rnd.Next(MinDays, MaxDays),
                Pack = _pack,
                Players = GeneratePlayers(users),
                Disaster = pack.Disasters.ElementAt(rnd.Next(_pack.Disasters.Count())),
                Bunker = GenerateBunker(playerCount),
                Abilities = GenerateAbilities()
            };
        }

        /// <summary>
        /// Исключение игрока
        /// </summary>
        /// <param name="id">Id исключаемого игрока</param>
        /// <returns>Возвращает исключенного игрока</returns>
        public Player KickPlayer(Guid id)
        {
            var player = _gameInfo.Players.First(p => p.UserId == id);
            player.IsKicked = true;

            return player;
        }

        //public void UseAbility(Player player, int abilityId)
        //{
        //    var ability = _gameInfo.Abilities.First(a => a.Id == abilityId);

        //    if (player.Abilities.FirstOrDefault(a => a.Id == ability.Id) != null)
        //    {
        //        if (ability is IGameAffectAbility gameAbility)
        //        {
        //            gameAbility.Use(this);
        //        }

        //        if (ability is IPlayerAffectAbility playerAbility)
        //        {
        //            playerAbility.Use(player);
        //        }
        //    }
        //}

        /// <summary>
        /// Генерация списка игроков
        /// </summary>
        /// <param name="users">Пользователи</param>
        /// <returns>Возвращает список игроков</returns>
        private List<Player> GeneratePlayers(IEnumerable<User> users)
        {
            var players = new List<Player>();

            foreach (var user in users)
            {
                players.Add(CreatePlayer(user));
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

        private List<IAbility> GenerateAbilitiesForPlayer()
        {
            return new List<IAbility>();
        }

        /// <summary>
        /// Создание карточки для пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Player CreatePlayer(User user)
        {
            Random rnd = new Random();

            return
                new Player
                {
                    UserId = user.Id,
                    Age = rnd.Next(MinPlayerAge, MaxPlayerAge),
                    Fact = _pack.Facts.ElementAt(rnd.Next(_pack.Facts.Count())),
                    Gender = (Gender)rnd.Next(0, 1),
                    Luggage = _pack.LuggageList.ElementAt(rnd.Next(_pack.LuggageList.Count())),
                    Health = _pack.Healths.ElementAt(rnd.Next(_pack.Healths.Count())),
                    Hobby = _pack.Hobbies.ElementAt(rnd.Next(_pack.Hobbies.Count())),
                    Abilities = GenerateAbilitiesForPlayer(),
                    Orientation = (Orientation)rnd.Next(0, 1),
                    IsKicked = false,
                    Profession = _pack.Professions.ElementAt(_pack.Professions.Count())
                };
        }

        /// <summary>
        /// Генерация бункера
        /// </summary>
        /// <param name="playerCount">Количество человек в бункере</param>
        /// <returns>Возвращает бункер</returns>
        private Bunker GenerateBunker(int playerCount)
        {
            Random rnd = new Random();

            return new Bunker(
                playerCount,
                rnd.Next(MinDays, MaxDays),
                _pack.Buildings.ElementAt(rnd.Next(_pack.Buildings.Count())),
                _pack.Buffs.ElementAt(rnd.Next(_pack.Buffs.Count())),
                _pack.Debuffs.ElementAt(rnd.Next(_pack.Debuffs.Count()))
            );
        }

    }
}
