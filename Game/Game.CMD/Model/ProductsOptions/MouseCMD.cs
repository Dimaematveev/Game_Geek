using Game.BL.Model.ProductsOptions;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model.ProductsOptions
{
    public class MouseCMD : Mouse, IConsole
    {
        public MouseCMD(string productName, int price) : base(productName, price)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft=spaceLeft;
            Console.WriteLine("Мышь:");
            Console.CursorLeft = spaceLeft+3;
            Console.WriteLine($"Название - {ProductName}");
            Console.CursorLeft = spaceLeft + 3;
            Console.WriteLine($"Цена без скидки - {Price}");
            Console.CursorLeft = spaceLeft + 3;
            Console.WriteLine($"Цена со скидкой - {GetPrice()}");
        }
    }
}
