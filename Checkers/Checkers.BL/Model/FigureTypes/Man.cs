using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model.FigureTypes
{
    /// <summary>
    /// Класс шашка.
    /// </summary>
    public class Man : Figure
    {
        public Man(int pozX, int pozY) : base(pozX, pozY)
        {
            
        }
        public override void Move(int ky, int kx)
        {
            if (Math.Abs(kx) != 1 || Math.Abs(ky) != 1)
            {
                throw new ArgumentException("Ход недопустим");
            }
            PozX += kx;
            PozY += ky;

        }
    }
}
