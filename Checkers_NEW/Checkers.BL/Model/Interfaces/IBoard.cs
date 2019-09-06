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

        /// <summary>
        /// Получить Позицию на ячейки.
        /// </summary>
        /// <param name="row">Ряд и меньше равна Rows и больше 0 </param>
        /// <param name="column">Столбец меньше равна Columns и больше 0 </param>
        /// <returns>Позиция в массиве</returns>
        int GetPosition(int row, int column);
        /// <summary>
        /// Проверка на то что такой столбец имеется. 
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">столбец</param>
        /// <returns><c>true</c> если есть <c>false</c> иначе</returns>
        bool CheckCell(int row,int column);


        /// <summary>
        /// Возможные ходы из этой клетки этим игроком
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">Колонка</param>
        /// <param name="CurrentPlayer">Игрок.</param>
        /// <returns>Список ходов.</returns>
        List<int> GetMov(int row, int column, IPlayer CurrentPlayer);

        /// <summary>
        /// Обязательные ходы из этой клетки этим игроком. Прыжки
        /// </summary>
        /// <param name="row">Ряд</param>
        /// <param name="column">Колонка</param>
        /// <param name="CurrentPlayer">Игрок.</param>
        /// <returns>Список ходов.</returns>
        List<int> GetJump(int row, int column, IPlayer CurrentPlayer);

    }
}
