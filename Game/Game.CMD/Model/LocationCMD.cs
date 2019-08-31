using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    class LocationCMD : Location, IConsole
    {
        public LocationCMD(string locationName) : base(locationName)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft = spaceLeft;
            Console.WriteLine($"Вы находитесь на локации {LocationName}.");
        }
    }
}
