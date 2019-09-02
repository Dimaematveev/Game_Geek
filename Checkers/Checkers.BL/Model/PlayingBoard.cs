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
            Figures = new Figure[NumY, NumX];
        }

        public void AddFigure(Figure figure)
        {
            if (Figures[figure.PozY, figure.PozX]==null)
            {
                Figures[figure.PozY, figure.PozX] = figure;
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
                if (Figures[figure.PozY, figure.PozX] == null)
                {
                    Figures[figure.PozY, figure.PozX] = figure;
                }
                else
                {
                    throw new ArgumentException("На этом месте уже стоит фигура!", nameof(Figures));
                }
            }
           
        }
        public bool CanGo(int y, int x)
        {

            
            if (IsEmptyCage(y + 1, x + 1) || IsEmptyCage(y + 1, x - 1) || IsEmptyCage(y - 1, x - 1) || IsEmptyCage(y - 1, x + 1))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Пуста такая клетка.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool IsEmptyCage(int y, int x)
        {
            if (y >= NumY || y < 0 || x >= NumX || x < 0) 
            {
                return false;
            }
            else if(Figures[y, x]==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
