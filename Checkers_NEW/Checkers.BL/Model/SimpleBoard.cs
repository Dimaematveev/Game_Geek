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
                throw new ArgumentException($"Размер доски должен быть четным и больше 0({rows})", nameof(rows));
            }
            if (columns <= 0 || columns % 2 == 1) 
            {
                throw new ArgumentException($"Размер доски должен быть четным и больше 0({columns})", nameof(columns));
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
                    throw new ArgumentException($"Позиция не должна быть меньше 1 и больше {Size} ({position})",nameof(position)); 
                }
                return CheckersCells[position - 1];
            }
            set
            {
                if (!CheckPosition(position))
                {
                    throw new ArgumentException($"Позиция не должна быть меньше 1 и больше {Size} ({position})", nameof(position));
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
                    throw new ArgumentException($"Ряд не должен быть меньше 1 и больше {Rows} ({row})", nameof(row));
                }
                if (!CheckColumn(column))
                {
                    throw new ArgumentException($"Столбец не должен быть меньше 1 и больше {Columns} ({column})", nameof(column));
                }
                return this[GetPosition(row, column)];
            }
            set
            {
                if (!CheckRow(row))
                {
                    throw new ArgumentException($"Ряд не должен быть меньше 1 и больше {Rows} ({row})", nameof(row));
                }
                if (!CheckColumn(column))
                {
                    throw new ArgumentException($"Столбец не должен быть меньше 1 и больше {Columns} ({column})", nameof(column));
                }
                this[GetPosition(row, column)] = value;
            }
        }

       
        /// <summary>
        /// Возможные ходы из этой клетки этим игроком
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">Колонка</param>
        /// <param name="CurrentPlayer">Игрок.</param>
        /// <returns>Список ходов. Если нет то null. первый в списке откуда ходит</returns>
        public List<int> GetMov(int row,int column ,IPlayer CurrentPlayer)
        {
            List<int> res = new List<int>();
           
            if ((row + column) % 2 == 1 && this[row, column] != null && this[row, column].Player == CurrentPlayer)
            {
                res.Add(this.GetPosition(row, column));
                foreach (var item in this[row, column].Piece.HowMoves)
                {
                    int changeRow = item.Row;
                    if (!this[row, column].Player.GoesForward)
                    {
                        changeRow = -item.Row;
                    }

                    int changeColumn = item.Column;
                    //Существует ячейка
                    bool CheckExistsCell = CheckCell(row + changeRow, column + changeColumn);
                    if (!CheckExistsCell)
                    {
                        continue;
                    }
                    //Эта ячейка пуста
                    bool IsEmptyCell = this[row + changeRow, column + changeColumn] == null;

                    if (IsEmptyCell) 
                    {
                        res.Add(this.GetPosition(row + changeRow, column + changeColumn));
                        
                    }
                }
            }
            if (res.Count>1)
            {
                return res;
            }
            return null;
        }



        /// <summary>
        /// Обязательные ходы из этой клетки этим игроком. Прыжки
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">Колонка</param>
        /// <param name="CurrentPlayer">Игрок.</param>
        /// <returns>Список ходов. Если нет то null. первый в списке откуда ходит</returns>
        public List<int> GetJump(int row, int column, IPlayer CurrentPlayer)
        {
            List<int> res = new List<int>();
            if (IsJump(row,column,CurrentPlayer))
            {
                res.Add(GetPosition(row, column));
            }
            if (res.Count>0)
            {
                return res;
            }
            return null;

        }
        /// <summary>
        /// Возможен прыжок из этой клетки этим игроком этой фигурой. Прыжки
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">Колонка</param>
        /// <param name="CurrentPlayer">Игрок.</param>
        /// <param name="CurrentPiece">Фигура.</param>
        /// <returns>True возможно false нет</returns>
        private bool IsJump(int row, int column, IPlayer CurrentPlayer)
        {
            if ((row + column) % 2 == 1 && this[row, column] != null && this[row, column].Player == CurrentPlayer)
            {
                
                foreach (var item in this[row, column].Piece.HowMoves)
                {
                    int changeRow = item.Row;
                    if (!this[row, column].Player.GoesForward)
                    {
                        changeRow = -item.Row;
                    }

                    int changeColumn = item.Column;

                    //Существует ячейка
                    bool CheckExistsCell = CheckCell(row + changeRow, column + changeColumn);
                    if (!CheckExistsCell)
                    {
                        continue;
                    }
                    //На ней враг
                    bool IsEnemyCell = this[row + changeRow, column + changeColumn] != null && this[row + changeRow, column + changeColumn].Player != CurrentPlayer;
                    
                    //Существует ячейка после
                    bool CheckExistsCellAfter = CheckCell(row + 2 * changeRow, column + 2 * changeColumn);
                    if (!CheckExistsCellAfter)
                    {
                        continue;
                    }
                    //Эта ячейка пуста
                    bool IsEmptyCellAfter = this[row + 2 * changeRow, column + 2 * changeColumn] == null;

                    if ( IsEnemyCell && IsEmptyCellAfter)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        /// <summary>
        /// Получить Позицию на ячейки.
        /// </summary>
        /// <param name="row">Ряд и меньше равна Rows и больше 0 </param>
        /// <param name="column">Столбец меньше равна Columns и больше 0 </param>
        /// <returns>Позиция в массиве</returns>
        public int GetPosition(int row, int column)
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

        /// <summary>
        /// Проверка на то что такой столбец имеется. 
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">столбец</param>
        /// <returns><c>true</c> если есть <c>false</c> иначе</returns>
        public bool CheckCell(int row, int column)
        {
            return CheckRow(row) && CheckColumn(column);
        }

    }
}
