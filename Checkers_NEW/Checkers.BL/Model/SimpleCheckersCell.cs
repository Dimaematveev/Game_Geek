using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    class SimpleCheckersCell : ICheckersCell
    {
        public SimpleCheckersCell(IPlayer player, IPiece piece)
        {
            Player = player;
            Piece = piece;
        }

        public IPlayer Player { get; }

        public IPiece Piece { get; }

    }
}
