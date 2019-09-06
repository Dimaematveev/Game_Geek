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
        //ICheckersCell[] CheckersCells { get; set; }


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


        /// <summary>
        /// Получить Клетку на позиции.
        /// </summary>
        /// <param name="position">Позиция из массива меньше равна Size и больше 0 </param>
        /// <returns>Клетка</returns>
        ICheckersCell this[int position] { get;set; }


        /// <summary>
        /// Получить Клетку на ячейки.
        /// </summary>
        /// <param name="row">Ряд и меньше равна Rows и больше 0 </param>
        /// <param name="column">Столбец меньше равна Columns и больше 0 </param>
        /// <returns>Клетка</returns>
        ICheckersCell this[int row, int column] { get;set; }

       

    }
}
