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
        private readonly ICheckersCell[] CheckersCells;

        /// <summary>
        /// Конструктор .
        /// </summary>
        /// <param name="rows">Сколько Рядов.</param>
        /// <param name="columns">Сколько строк.</param>
        public SimpleBoard(int rows, int columns)
        {
            if (rows <= 0 || rows % 2 == 1) 
            {
                throw new ArgumentException("Размер доски должен быть четным и больше 0", nameof(rows));
            }
            if (columns <= 0 || columns % 2 == 1) 
            {
                throw new ArgumentException("Размер доски должен быть четным и больше 0", nameof(columns));
            }
            Size = rows * columns / 2;
            CheckersCells = new ICheckersCell[Size];
            Rows = rows;
            Columns = columns;
        }
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
                if (!CheckPosition(position))
                {
                    throw new ArgumentException($"Позиция не должна быть меньше 1 и больше {Size}",nameof(position)); 
                }
                return CheckersCells[position - 1];
            }
            set
            {
                if (!CheckPosition(position))
                {
                    throw new ArgumentException($"Позиция не должна быть меньше 1 и больше {Size}", nameof(position));
                }
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
                if (!CheckRow(row))
                {
                    throw new ArgumentException($"Ряд не должен быть меньше 1 и больше {Rows}", nameof(row));
                }
                if (!CheckColumn(column))
                {
                    throw new ArgumentException($"Столбец не должен быть меньше 1 и больше {Columns}", nameof(column));
                }
                return this[GetPosition(row, column)];
            }
            set
            {
                if (!CheckRow(row))
                {
                    throw new ArgumentException($"Ряд не должен быть меньше 1 и больше {Rows}", nameof(row));
                }
                if (!CheckColumn(column))
                {
                    throw new ArgumentException($"Столбец не должен быть меньше 1 и больше {Columns}", nameof(column));
                }
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

        /// <summary>
        /// Проверка на то что такая позиция имеется
        /// </summary>
        /// <param name="position">Позиция</param>
        /// <returns><c>true</c> если есть <c>false</c> иначе</returns>
        private bool CheckPosition(int position)
        {
            if (position <= 0 || position > Size)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на то что такой ряд имеется
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <returns><c>true</c> если есть <c>false</c> иначе</returns>
        private bool CheckRow(int row)
        {
            if (row <= 0 || row > Rows)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Проверка на то что такой столбец имеется. 
        /// </summary>
        /// <param name="column">столбец</param>
        /// <returns><c>true</c> если есть <c>false</c> иначе</returns>
        private bool CheckColumn(int column)
        {
            if (column <= 0 || column > Columns)
            {
                return false;
            }
            return true;
        }
    }
}
