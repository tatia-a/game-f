namespace Board
{
    public class Game
    {
        int size;
        Map map;
        Coord space;

        public int moves { get; private set; }

        // Конструктор класса
        public Game (int size)
        {
            this.size = size;
            map = new Map (size);
        }

        // Старт (заполнение плитками)
        public void Start(int seed = 0)
        {
            int dijit = 0;
            //YeldCoord создает коллекцию по размеру, а форич ее перебирает
            foreach (Coord xy in new Coord().YieldCoord(size))
                map.Set(xy, ++dijit);
            space = new Coord(size);
            if (seed > 0)
                Shuffle(seed);
            moves = 0;
        }
        // Рандомная сортировка
        private void Shuffle(int seed)
        {
            Random r = new Random();
            // Метод может тыкать по клеткам, которые нельзя подвинуть
            // полагаю, более оптимальный рандомайзер можено сделать с листом
            for (int j = 0; j < size; j++)
            {
                PressAt(r.Next(size), r.Next(size));
            }
        }

        // Нажатие на кнопку, возвращает количество шагов
        public int PressAt (int x, int y)
        {
            return PressAt(new Coord(x, y));
        }
        int PressAt(Coord xy)
        {

            if (space.Equals(xy)) return 0; // если щелкнули по пустоте
            if (xy.x != space.x &&
                xy.y != space.y) return 0; // ход должен совершаться в том ряду и столбце, где пустая клетка

            int steps = Math.Abs(xy.x - space.x) 
                      + Math.Abs(xy.y - space.y); // вычисляется количество шагов за ход,
                                                  // можно просто внутри циклов прибавлять (не выёбываться)

            while (xy.x != space.x)
            {
                Shift(Math.Sign(xy.x - space.x), 0);
            }
            while (xy.y != space.y)
            {
                Shift(0, Math.Sign(xy.y - space.y));
            }

            moves += steps;

            return steps;
        }
        /// <summary>
        /// Метод для смещения плитки
        /// </summary>
        /// <param name="sx"></param>
        /// <param name="sy"></param>
        private void Shift(int sx, int sy)
        {
            Coord next = space.Add(sx, sy);
            map.Copy(next, space); // map[space] = map[next]
            space = next;
        }

        /// <summary>
        /// Получить число на клетке
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetDijitAt (int x, int y)
        {
            return GetDijitAt(new Coord(x, y));
        }

        int GetDijitAt(Coord xy)
        {
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }
        /// <summary>
        /// Решена ли игра
        /// </summary>
        /// <returns></returns>
        public bool Solved ()
        {
            if (!space.Equals (new Coord(size)))
                return false;

            int dijit = 0;

            foreach(Coord xy in new Coord().YieldCoord(size))
            {
                if (map.Get(xy) != ++dijit)
                {
                    return space.Equals(xy); // просто для пробела данное условие не выполнится
                }
            }

            return true;
        }
    }
}