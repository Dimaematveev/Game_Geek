using Checkers.BL.Controller;
using Checkers.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingBoard playingBoard = new PlayingBoard();

            Team blackTeam = new Team(TeamColor.black, playingBoard);
            Team whiteTeam = new Team(TeamColor.white, playingBoard);

            PlayController playController = new PlayController(whiteTeam, blackTeam, playingBoard);

            for (int i = 0; i < playingBoard.NumY; i++)
            {
                Console.Write("|");
                for (int j = 0; j < playingBoard.NumX; j++)
                {
                    var figB= blackTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                    if (figB!=null)
                    {
                        Console.Write("black");
                    }
                    var figW = whiteTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                    if (figW != null)
                    {
                        Console.Write("white");
                    }
                    Console.Write("\t|");
                }
                Console.WriteLine();
            }

            blackTeam.Move(2, 1, 3, 2);
            for (int i = 0; i < playingBoard.NumY; i++)
            {
                Console.Write("|");
                for (int j = 0; j < playingBoard.NumX; j++)
                {
                    var figB = blackTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                    if (figB != null)
                    {
                        Console.Write("black");
                    }
                    var figW = whiteTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                    if (figW != null)
                    {
                        Console.Write("white");
                    }
                    Console.Write("\t|");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
