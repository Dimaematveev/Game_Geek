using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Клетка на доске.
    /// </summary>
    class SimpleCheckersCell : ICheckersCell
    {
        public SimpleCheckersCell(IPlayer player, IPiece piece)
        {
            Player = player;
            Piece = piece;
        }
        /// <summary>
        /// Игрок.
        /// </summary>
        public IPlayer Player { get; }
        /// <summary>
        /// Фигура.
        /// </summary>
        public IPiece Piece { get; }

    }
}
