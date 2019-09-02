using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.FigureTypes
{
    /// <summary>
    /// Класс дамка.
    /// </summary>
    public class King : Figure
    {
        public King(int pozX, int pozY) : base(pozX, pozY)
        {
        }
        public override void Move(int ky, int kx)
        {
            if (Math.Abs(kx) != Math.Abs(ky))
            {
                throw new ArgumentException("Ход недопустим");
            }
            PozX += kx;
            PozY += ky;

        }
    }
}
