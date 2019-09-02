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
        public bool CanGo(int y, int x, int k)
        {

            
            if (IsEmptyCage(y + k, x + 1) || IsEmptyCage(y + k, x - 1))
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

        public bool MustFight(int y, int x)
        {
            if ((IsEnemyCage(y, x,1,1)) || (IsEnemyCage(y, x,-1,1)) || (IsEnemyCage(y, x,1,-1)) || (IsEnemyCage(y, x,-1,-1)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Противник на этой клетке и на следующей пусто?
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        private bool IsEnemyCage(int y, int x, int ky, int kx)
        {
            if (y+ky >= NumY || y+ky < 0 || x+kx >= NumX || x+kx < 0)
            {
                return false;
            }
            else if (Figures[y + ky, x + kx]!=null && Figures[y, x].Team != Figures[y+ky, x+kx].Team)
            {
                return IsEmptyCage(y + 2 * ky, x + 2 * kx);
                
            }
            else
            {
                return false;
            }
        }
    }
}
