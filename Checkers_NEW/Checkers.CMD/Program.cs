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
            while (true)
            {
                var WhitePos = playController.GetPossibleMoves();
                var WhiteJump = playController.GetJump();

                playController.ChangePlayer();
                var BlackPos = playController.GetPossibleMoves();
                var BlackJump = playController.GetJump();
                playController.ChangePlayer();
                Console.WriteLine();
                Draw(playController);
                Console.WriteLine("Введи откуда пойдешь");
                int pos;
                while (!int.TryParse(Console.ReadLine(),out pos) || pos <= 0 || pos > 32)
                {
                    Console.WriteLine("Неверно");
                }
                Console.WriteLine("Введи куда пойдешь");
                int posnew = int.Parse(Console.ReadLine());
                playController.Move(pos, posnew);
                
            }
            

            
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
