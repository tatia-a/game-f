using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    struct Coord
    {
        public int x;  
        public int y;
        /// <summary>
        /// Конструктор структуры Coord, использующий координаты клетки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Конструктор структуры Coord для последней клетки
        /// </summary>
        /// <param name="size"></param>
        public Coord(int size)
        {
            this.x = size - 1;
            this.y = size - 1;
        }
        public bool OnBoard (int size)
        {
            if (x < 0 || x > size - 1) return false;
            if (y < 0 || y > size - 1) return false;
            return true;
        }
        public IEnumerable<Coord> YieldCoord (int size)
        {
            for (y = 0; y < size; y++)
                for (x = 0; x < size; x++)
                    yield return this;
        }

        public Coord Add(int sx, int sy)
        {
            return new Coord(x + sx, y + sy);
        }
    }
}
