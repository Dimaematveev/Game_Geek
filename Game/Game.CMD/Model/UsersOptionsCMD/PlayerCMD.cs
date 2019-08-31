using Game.BL.Model.LocationsOptions;
using Game.BL.Model.UsersOptions;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model.UsersOptionsCMD
{
    public class PlayerCMD : Player, IConsole
    {
        public PlayerCMD(string name, Home currentHome) : base(name, currentHome)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft = spaceLeft;
            Console.WriteLine($"Игрок:");
            Console.CursorLeft = spaceLeft+3;
            Console.WriteLine($"Имя - {UserName},");
            Console.CursorLeft = spaceLeft+3;
            Console.WriteLine($"Монет - {Money},");
            
            ((IConsole)(CurrentHome)).ToConsole(spaceLeft + 3);
        }
    }
}
