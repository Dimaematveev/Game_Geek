using Game.BL.Model.LocationsOptions;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model.LocationsOptions
{
    class ShopCMD : Shop, IConsole
    {
        public ShopCMD(string locationName) : base(locationName)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft = spaceLeft;
            Console.WriteLine($"Магазин:");
            Console.CursorLeft = spaceLeft + 3;
            Console.WriteLine($"Название - {LocationName}.");
        }
        public void Price(int spaceLeft)
        {
            foreach (var product in Products)
            {
                ((IConsole)product).ToConsole(spaceLeft + 3);
            }
        }
    }
}
