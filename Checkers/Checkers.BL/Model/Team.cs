using Checkers.BL.Model.FigureTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    public enum TeamColor { white = 0, black = 1 };
    public class Team
    {
        public List<Figure> Figures { get; private set; }
        private TeamColor TeamColor;
        public PlayingBoard PlayingBoard { get; private set; }
        public Team(TeamColor teamColor, PlayingBoard playingBoard)
        {
            TeamColor = teamColor;
            PlayingBoard = playingBoard;
            Figures = new List<Figure>();
        }
        /// <summary>
        /// Добавить фигуры;
        /// </summary>
        public void AddFigure(int pozY, int pozX)
        {
            if (Figures.FindIndex(f=>(f.PozX== pozX && f.PozY == pozY))!=-1)
            {
                throw new ArgumentException("На этом месте уже стоит фигура!", nameof(Figures));
            }
            Figures.Add(new Man(pozX, pozY,this));
        }

        public void Move(int y, int x, int yNew, int xNew)
        {
            var fig = Figures.Find(f => (f.PozX == x && f.PozY == y));
            if (fig == null)
            {
                throw new ArgumentException("На этом месте Нет фигуры!", nameof(Figures));
            }
            fig.Move(yNew - y, xNew - x);
        }

    }
}
