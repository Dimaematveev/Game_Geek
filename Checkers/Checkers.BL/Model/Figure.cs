using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Класс фигур.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Позиция по X.
        /// </summary>
        private int _pozX;
        /// <summary>
        /// Позиция по Y.
        /// </summary>
        private int _pozY;
        /// <summary>
        /// Свойство позиции по X.
        /// </summary>
        public int PozX
        {
            get => _pozX;
            protected set
            {
                if (value < 0 || value > 7 )
                {
                    throw new ArgumentException("Позиция шашки не может быть больше 8 и меньше 1!", nameof(PozX));
                }
                _pozX = value;
            }

        }
        /// <summary>
        /// Свойство позиции по Y.
        /// </summary>
        public int PozY
        {
            get => _pozY;
            protected set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("Позиция шашки не может быть больше 7 и меньше 0!", nameof(PozX));
                }
                _pozY = value;
            }

        }

        public Figure(int pozX, int pozY)
        {
            PozX = pozX;
            PozY = pozY;
        }

        public virtual void Move(int kx,int ky)
        {

        }
    }
}
