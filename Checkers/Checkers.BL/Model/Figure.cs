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
        protected int PozX
        {
            get => _pozX;
            private set
            {
                if (value < 1 || value > 8 )
                {
                    throw new ArgumentException("Позиция шашки не может быть больше 8 и меньше 1!", nameof(PozX));
                }
                _pozX = value;
            }

        }
        /// <summary>
        /// Свойство позиции по Y.
        /// </summary>
        protected int PozY
        {
            get => _pozY;
            private set
            {
                if (value < 1 || value > 8)
                {
                    throw new ArgumentException("Позиция шашки не может быть больше 8 и меньше 1!", nameof(PozX));
                }
                _pozY = value;
            }

        }

        public Figure(int pozX, int pozY)
        {
            PozX = pozX;
            PozY = pozY;
            
        }
    }
}
