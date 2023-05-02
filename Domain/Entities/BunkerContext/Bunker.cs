namespace Domain.Entities.BunkerContext
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
        public BunkerBuilding Building { get; set; }

        /// <summary>
        /// Хорошая составляющая бункера
        /// </summary>
        public BunkerBuff Buff { get; set; }

        /// <summary>
        /// Поломка или отрицательный эффект бункера
        /// </summary>
        public BunkerDebuff Debuff { get; set; }

        /// <summary>
        /// Создание бункера
        /// </summary>
        /// <param name="size">Вместимость</param>
        /// <param name="foodCount">Количество еды</param>
        /// <param name="building">Постройка</param>
        /// <param name="buff">Бафф</param>
        /// <param name="debuff">Дебафф</param>
        public Bunker(int size, int foodCount, BunkerBuilding building, BunkerBuff buff, BunkerDebuff debuff)
        {
            Size = size;
            FoodCount = foodCount;
            Building = building;
            Buff = buff;
            Debuff = debuff;
        }
    }
}
