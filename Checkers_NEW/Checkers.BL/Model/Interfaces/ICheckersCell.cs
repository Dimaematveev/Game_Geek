using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.Interfaces
{
    /// <summary>
    /// Интерфейс клетки на доске.
    /// </summary>
    public interface ICheckersCell
    {
        /// <summary>
        /// Игрок.
        /// </summary>
        IPlayer Player { get; }
        /// <summary>
        /// Фигура.
        /// </summary>
        IPiece Piece { get; }
    }
}
