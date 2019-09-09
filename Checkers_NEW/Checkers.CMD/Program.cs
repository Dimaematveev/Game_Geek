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
            while (true)
            {
                Console.WriteLine($"Вы игрок {playController.CurrentPlayer.Name}");
                //список(список где 0 элемент откуда вожможно движени, а дальше куда)
                var Pos = playController.GetPossibleMoves();
                //список(список где 0 элемент откуда должно движени, а дальше куда)
                var Jump = playController.GetJump();



                List<int> Posit;
                Console.WriteLine();
                Draw(playController);
                if (Jump != null)
                {
                    Console.WriteLine("Должен бить:");
                    Posit = Jump.ConvertAll(j => j[0]);
                }
                else
                {
                    Console.WriteLine("Введи откуда пойдешь:");
                    Posit = Pos.ConvertAll(p => p[0]);
                }

                ////Список всех возможных фигуг двигающиеся
                //var Posit = Pos.ConvertAll(p => p[0]);
                ////Список все возможных движений
                //var Jumpt = Jump.ConvertAll(j => j[0]);

                int pos;
                while (!int.TryParse(Console.ReadLine(),out pos) || !Posit.Contains(pos))
                {
                    Console.WriteLine("Неверно");
                }
                //Список все возможных движений
                //var Positio = Pos.Find(p=>p[0]==pos).Skip(1);

                List<int> Positio;
                if (Jump != null)
                {
                    Console.WriteLine("Введи кого будешь бить пойдешь");
                    Positio = Jump.FindAll(j => j[0] == pos).Select(j => j[1]).ToList();
                }
                else
                {
                    Console.WriteLine("Введи куда пойдешь");
                    Positio = Pos.Find(p => p[0] == pos).Skip(1).ToList();
                }
                
                int posnew;
                while(!int.TryParse(Console.ReadLine(), out posnew) || !Positio.Contains(posnew))
                {
                    Console.WriteLine("Неверно");
                }
                playController.Move(pos, posnew);
                playController.ChangePlayer();
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
