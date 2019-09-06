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
    public class SimpleCheckersCell : ICheckersCell
    {
        public SimpleCheckersCell(IPlayer player, IPiece piece)
        {
            if (player == null)
            {
                throw new ArgumentException($"Игрок не должен быть пустым ({player})", nameof(player));
            }
            if (piece == null)
            {
                throw new ArgumentException($"Фигура не должна быть пустой ({piece})", nameof(piece));
            }
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
