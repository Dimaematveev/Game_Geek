using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.Interfaces
{
    /// <summary>
    /// Интерфейс игрока.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// ID игрока.
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Имя игрока.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Куда ходит игрок вперед или назад. Черные вперед белые назад
        /// </summary>
        bool GoesForward { get; }
    }
}
