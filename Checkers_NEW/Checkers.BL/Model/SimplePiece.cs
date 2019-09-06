using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Шахматная Фигура. 
    /// </summary>
    public class SimplePiece : IPiece
    {
        public SimplePiece(string name, IEnumerable<IHowMove> howMoves)
        {
            Name = name;
            HowMoves = howMoves;
        }
        /// <summary>
        /// ID Фигуры.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Имя фигуры.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Возможные движения.
        /// </summary>
        public IEnumerable<IHowMove> HowMoves { get; }
    }
}
