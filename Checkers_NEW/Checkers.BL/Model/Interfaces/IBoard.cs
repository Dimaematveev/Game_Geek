using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.Interfaces
{
    /// <summary>
    /// Интерфейс Игровой доски.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Массив клеток на которых возможно играть.
        /// </summary>
        ICheckersCell[] CheckersCells { get; set; }
        /// <summary>
        /// Id Доски.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Количество клеток в которых можно перемещаться. (Для шашек только белые.) 
        /// Количество позиций!
        /// </summary>
        int Size { get; }
        /// <summary>
        /// Получить количество рядов.
        /// </summary>
        int Rows { get; }
        /// <summary>
        /// Получить количество столбцов.
        /// </summary>
        int Columns { get; }


        /// /// <summary>
        /// Получить фигуру в позиции.
        /// </summary>
        /// <param name="position"> Позиция не больше Size!</param>
        /// <returns>Фигура.</returns>
        IPiece GetPiece(int position);


        /// <summary>
        /// Получить фигуру на месте.
        /// </summary>
        /// <param name="row"> Ряд не больше Rows!</param>
        /// <param name="column"> Столбец не больше Columns!</param>
        /// <returns>Фигура.</returns>
        IPiece GetPiece(int row, int column);

        /// /// <summary>
        /// Получить Игрока в позиции.
        /// </summary>
        /// <param name="position"> Позиция не больше Size!</param>
        /// <returns>Игрок.</returns>
        IPlayer GetPlayer(int position);

        /// <summary>
        /// Получить Игрока на месте.
        /// </summary>
        /// <param name="row"> Ряд не больше Rows!</param>
        /// <param name="column"> Столбец не больше Columns!</param>
        /// <returns>Игрок.</returns>
        IPlayer GetPlayer(int row, int column);

    }
}
