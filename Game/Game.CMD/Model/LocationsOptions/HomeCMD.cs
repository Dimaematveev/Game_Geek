using Game.BL.Model.LocationsOptions;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model.LocationsOptions
{
    public class HomeCMD : Home, IConsole
    {
        public HomeCMD(string locationName) : base(locationName)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft=spaceLeft;
            Console.WriteLine($"Дом:");
            Console.CursorLeft=spaceLeft+3;
            Console.WriteLine($"Название - {LocationName}.");
        }
    }
}
