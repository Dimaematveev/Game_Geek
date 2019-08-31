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

        public void ToConsole()
        {
            
            ((IConsole)CurrentLocation).ToConsole();
            ((IConsole)CurrentUser).ToConsole();

        }
    }
}
