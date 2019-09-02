using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Класс игральная доска!
    /// </summary>
    public class PlayingBoard
    {
        

        /// <summary>
        /// Количество ячеек по оси X.
        /// </summary>
        public int NumX { get; private set; }
        /// <summary>
        /// Количество ячеек по оси Y.
        /// </summary>
        public int NumY { get; private set; }
        public Figure[,] Figures { get;private set; }

        public PlayingBoard()
        {
            NumX = 8;
            NumY = 8;
            Figures = new Figure[NumX, NumY];
        }

        public void AddFigure(Figure figure)
        {
            if (Figures[figure.PozX, figure.PozY]==null)
            {
                Figures[figure.PozX, figure.PozY] = figure;
            }
            else
            {
                throw new ArgumentException("На этом месте уже стоит фигура!", nameof(Figures));
            }
        }
        public void AddFigure(List<Figure> figures)
        {
            foreach (var figure in figures)
            {
                if (Figures[figure.PozX, figure.PozY] == null)
                {
                    Figures[figure.PozX, figure.PozY] = figure;
                }
                else
                {
                    throw new ArgumentException("На этом месте уже стоит фигура!", nameof(Figures));
                }
            }
           
        }
    }
}
