using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.Interfaces
{
    /// <summary>
    /// Интерфейс шахматной Фигуры. 
    /// </summary>
    public interface IPiece
    {
        /// <summary>
        /// ID Фигуры.
        /// </summary>
        int Id { get;  }
        /// <summary>
        /// Имя фигуры.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Возможные движения.
        /// </summary>
        IEnumerable<IHowMove> HowMoves { get; }
    }
}
