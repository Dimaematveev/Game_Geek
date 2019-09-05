using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    public class SimpleHowMove : IHowMove
    {
        public SimpleHowMove(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Id { get; }

        public int Row { get; }

        public int Column { get; }
    }
}
