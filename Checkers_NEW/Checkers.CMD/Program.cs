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
            //знаков '-'
            const int numStr = 52;
            //на ячейку
            const int numCell = 5;
            //на ряд с номерами
            const int numNum = 2;
            PlayController playController = new PlayController();

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
                        Console.Write($"{temp, numCell}|");
                    }
                    else
                    {
                        Console.Write(new string('*', numCell)+"|");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', numStr));
            }

            Console.ReadLine();
        }
    }
}
