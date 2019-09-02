using Checkers.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Controller
{
    public class PlayController
    {
       

        private Team TeamWhite { get; set; }
        private Team TeamBlack { get; set; }
        public PlayingBoard PlayingBoard { get; private set; }
        public Team CurrentTeam { get; private set; }

        public PlayController(Team teamWhite, Team teamBlack, PlayingBoard playingBoard)
        {
            TeamWhite = teamWhite;
            TeamBlack = teamBlack;
            TeamChange();
            PlayingBoard = playingBoard;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < playingBoard.NumX; j++)
                {
                    if ((i+j)%2==1)
                    {
                        TeamBlack.AddFigure(i, j);
                    }
                    if ((playingBoard.NumY - i - 1 + j) % 2 == 1)
                    {
                        TeamWhite.AddFigure(playingBoard.NumY - i - 1, j);
                    }
                    
                }
            }
            PlayingBoard.AddFigure(TeamBlack.Figures);
            PlayingBoard.AddFigure(TeamWhite.Figures);
        }
        public void Move(int y, int x, int ky, int kx)
        {
            CurrentTeam.Move(y, x, y + ky, x + kx);

            PlayingBoard.Figures[y + ky, x + kx] = PlayingBoard.Figures[y, x];
            PlayingBoard.Figures[y, x] = null;
        }
        public void TeamChange()
        {
            if (CurrentTeam==TeamWhite)
            {
                CurrentTeam = TeamBlack;
            }
            else
            {
                CurrentTeam = TeamWhite;
            }
        }
        public List<Figure> CanGo()
        {
            var res = new List<Figure>();
            foreach (var figure in CurrentTeam.Figures)
            {
                if (CurrentTeam.PlayingBoard.CanGo(figure.PozY, figure.PozX))
                {
                    res.Add(figure);
                }
            }
            return res;
        }
    }
}
