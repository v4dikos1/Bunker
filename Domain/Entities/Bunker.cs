namespace Domain.Entities
{
    /// <summary>
    /// Бункер
    /// </summary>
    public class Bunker
    {
        /// <summary>
        /// Вместимость бункера (кол-во человек)
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Время, на которое хватит еды в бункере, рассчитанное на полную загрузку бункера (количество дней)
        /// </summary>
        public int FoodCount { get; }

        /// <summary>
        /// Постройка в бункере
        /// </summary>
        public BunkerItem Building { get; set; } = null!;

        /// <summary>
        /// Хорошая составляющая бункера
        /// </summary>
        public BunkerItem Buff { get; set; } = null!;

        /// <summary>
        /// Поломка или отрицательный эффект бункера
        /// </summary>
        public BunkerItem Debuff { get; set; } = null!;

        /// <summary>
        /// Создание бункера
        /// </summary>
        /// <param name="size">Вместимость</param>
        /// <param name="foodCount">Количество еды</param>
        /// <param name="building">Постройка</param>
        /// <param name="buff">Бафф</param>
        /// <param name="debuff">Дебафф</param>
        public Bunker(int size, int foodCount, BunkerItem building, BunkerItem buff, BunkerItem debuff)
        {
            Size = size;
            FoodCount = foodCount;
            Building = building;
            Buff = buff;
            Debuff = debuff;
        }
    }
}
