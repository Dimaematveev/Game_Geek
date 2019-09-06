using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Возможное движение фигуры.
    /// </summary>
    public class SimpleHowMove : IHowMove
    {
        public SimpleHowMove(int row, int column)
        {
            Row = row;
            Column = column;
        }
        /// <summary>
        /// Id возможных движений движения.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// На сколько рядов ходит.
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// На сколько колонок ходит.
        /// </summary>
        public int Column { get; }
    }
}
