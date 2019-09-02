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
       

        Team TeamWhite { get; set; }
        Team TeamBlack { get; set; }
        PlayingBoard PlayingBoard { get; set; }

        public PlayController(Team teamWhite, Team teamBlack, PlayingBoard playingBoard)
        {
            TeamWhite = teamWhite;
            TeamBlack = teamBlack;
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
    }
}
