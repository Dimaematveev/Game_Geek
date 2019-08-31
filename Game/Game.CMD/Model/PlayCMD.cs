using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    class PlayCMD : Play, IConsole
    {
        public PlayCMD(User currentUser, Location currentLocation) : base(currentUser, currentLocation)
        {
            Console.WriteLine("Вы начали игру!");
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft = spaceLeft;
            Console.WriteLine("Локация:");
            
            ((IConsole)CurrentLocation).ToConsole(spaceLeft+3);
            Console.CursorLeft = spaceLeft;
            Console.WriteLine("Ваш персонаж:");
            ((IConsole)CurrentUser).ToConsole(spaceLeft+3);

            

        }
    }
}
