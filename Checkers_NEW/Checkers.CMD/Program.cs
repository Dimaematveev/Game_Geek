using Checkers.BL.Controller;
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
            
            PlayController playController = new PlayController();
            Draw(playController);
            var White = playController.GetPossibleMoves();
            playController.ChangePlayer();
            var Black = playController.GetPossibleMoves();
            playController.Move(3, 2, 4, 1);
            Console.WriteLine();
            Draw(playController);
            Console.ReadLine();
        }

        private static void Draw(PlayController playController)
        {
            //знаков '-'
            const int numStr = 82;
            //на ячейку
            const int numCell = 8;
            //на ряд с номерами
            const int numNum = 2;
            Console.Write($"|{"",numNum}|");
            for (int c = 1; c <= playController.Column; c++)
            {
                Console.Write($"{c,numCell}|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', numStr));
            for (int r = 1; r <= playController.Row; r++)
            {
                Console.Write($"|{r,numNum}|");

                for (int c = 1; c <= playController.Column; c++)
                {
                    if ((r + c) % 2 == 1)
                    {
                        var temp = playController.CheckersCell(r, c);
                        Console.Write($"{temp,numCell}|");
                    }
                    else
                    {
                        Console.Write(new string('*', numCell) + "|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', numStr));
            }
        }
    }
}
