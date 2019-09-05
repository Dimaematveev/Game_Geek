using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    public class SimplePiece : IPiece
    {
        public SimplePiece(string name, IEnumerable<IHowMove> howMoves)
        {
            Name = name;
            HowMoves = howMoves;
        }

        public int Id { get; }

        public string Name { get; }

        public IEnumerable<IHowMove> HowMoves { get; }
    }
}
