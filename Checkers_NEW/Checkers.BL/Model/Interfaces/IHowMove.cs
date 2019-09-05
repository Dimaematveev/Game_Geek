using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.Interfaces
{
    /// <summary>
    /// Интерфейс возможного движения фигуры.
    /// </summary>
    public interface IHowMove
    {
        /// <summary>
        /// Id движения.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// На сколько рядов ходит.
        /// </summary>
        int Row { get;  }
        /// <summary>
        /// На сколько колонок ходит.
        /// </summary>
        int Column { get;  }
    }
}
