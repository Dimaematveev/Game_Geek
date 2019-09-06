using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Простая доска.
    /// </summary>
    public class SimpleBoard : IBoard
    {
        /// <summary>
        /// Массив клеток на которых возможно играть.
        /// </summary>
        public ICheckersCell[] CheckersCells { get; set; }
        /// <summary>
        /// Конструктор .
        /// </summary>
        /// <param name="size">Сколько клеток на которых можно играть.</param>
        /// <param name="rows">Сколько Рядов.</param>
        /// <param name="columns">Сколько строк.</param>
        public SimpleBoard(int size, int rows, int columns)
        {
            if (size % 2 == 1)
            {
                throw new ArgumentException("Размер доски должен быть четным", nameof(size));
            }
            if (rows % 2 == 1)
            {
                throw new ArgumentException("Размер доски должен быть четным", nameof(rows));
            }
            if (columns % 2 == 1)
            {
                throw new ArgumentException("Размер доски должен быть четным", nameof(columns));
            }
            Size = size;
            CheckersCells = new ICheckersCell[Size];
            Rows = rows;
            Columns = columns;
        }
        /// <summary>
        /// Конструктор .
        /// </summary>
        /// <param name="rows">Сколько Рядов.</param>
        /// <param name="columns">Сколько строк.</param>
        public SimpleBoard(int rows, int columns) : this(rows * columns / 2, rows, columns){    }
        /// <summary>
        /// Конструктор .
        /// </summary>
        /// <param name="num">Сколько строк и рядов. Так как квадратная доска.</param>
        public SimpleBoard(int num):this(num,num){  }
        /// <summary>
        /// ID.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Количество игральных ячеек.
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// Количество рядов
        /// </summary>
        public int Rows { get; }
        /// <summary>
        /// Количество столбцов.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Получить Клетку на позиции.
        /// </summary>
        /// <param name="position">Позиция из массива меньше равна Size и больше 0 </param>
        /// <returns>Клетка</returns>
        public ICheckersCell this[int position]
        {
            get 
            {
                return CheckersCells[position - 1];
            }
            set
            {
                CheckersCells[position - 1] = value;
            }
        }
        /// <summary>
        /// Получить Клетку на ячейки.
        /// </summary>
        /// <param name="row">Ряд и меньше равна Rows и больше 0 </param>
        /// <param name="column">Столбец меньше равна Columns и больше 0 </param>
        /// <returns>Клетка</returns>
        public ICheckersCell this[int row, int column]
        {
            get
            {
                return this[GetPosition(row, column)];
            }
            set
            {
                this[GetPosition(row, column)] = value;
            }
        }

       
        /// <summary>
        /// Получить Позицию на ячейки.
        /// </summary>
        /// <param name="row">Ряд и меньше равна Rows и больше 0 </param>
        /// <param name="column">Столбец меньше равна Columns и больше 0 </param>
        /// <returns>Позиция в массиве</returns>
        private int GetPosition(int row, int column)
        {
            return ((row - 1) * 4 + (column - 1) / 2) + 1;
        }

        /// <summary>
        /// Получить Ряд на позиции.
        /// </summary>
        /// <param name="position">Позиция из массива меньше равна Size и больше 0 </param>
        /// <returns>Ряд</returns>
        private int GetRow(int position)
        {
            return ((position-1)/4)+1;
        }
        /// <summary>
        /// Получить Столбец на позиции.
        /// </summary>
        /// <param name="position">Позиция из массива меньше равна Size и больше 0 </param>
        /// <returns>Столбец</returns>
        private int GetColumn(int position)
        {
            return (((position - 1) % 4)*2+(GetRow(position)%2)+1);

        }
    }
}
