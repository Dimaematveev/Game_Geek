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
            do
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"|{"",2}|");
                for (int j = 0; j < playingBoard.NumX; j++)
                {
                    Console.Write($"{j,6}|");
                }
                Console.WriteLine();
                for (int i = 0; i < playingBoard.NumY; i++)
                {

                    Console.Write($"|{i,2}|");
                    for (int j = 0; j < playingBoard.NumX; j++)
                    {
                        var figB = blackTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                        if (figB != null)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{"black",6}");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        var figW = whiteTeam.Figures.Find(f => f.PozX == j && f.PozY == i);
                        if (figW != null)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"{"white",6}");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        if (figB == null && figW == null)
                        {
                            Console.Write($"{"",6}");
                        }
                        Console.Write("|");
                    }
                    Console.WriteLine();
                }
                if (playController.CurrentTeam== blackTeam)
                {
                    Console.WriteLine("Ходят черные");
                }
                else
                {
                    Console.WriteLine("Ходят белые");
                }
               
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("Введите номер строки:");
                int y;
                var resY = playController.CanGo().Select(f => f.PozY).ToArray();
                while (!(int.TryParse(Console.ReadLine(), out y)) || !(resY.Contains(y)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверно ввели: так как нет такого номера. Введите заново!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("Введите номер столбца:");
                int x;
                var resX = playController.CanGo().Where(f => f.PozY == y).Select(f => f.PozX).ToArray();
                while (!(int.TryParse(Console.ReadLine(), out x)) || !(resX.Contains(x)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверно ввели: так как нет такого номера. Введите заново!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("Введите номер строки куда пойдет:");
                int yNew;
                while (!(int.TryParse(Console.ReadLine(), out yNew)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверно ввели: так как нет такого номера. Введите заново!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine("Введите номер столбец куда пойдет:");
                int xNew;
                while (!(int.TryParse(Console.ReadLine(), out xNew)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверно ввели: так как нет такого номера. Введите заново!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                playController.Move(y, x, yNew - y, xNew - x);
                Console.WriteLine(new String('-', 90));
                playController.TeamChange();
            }
            while (true);
            Console.ReadLine();
        }
    }
}
