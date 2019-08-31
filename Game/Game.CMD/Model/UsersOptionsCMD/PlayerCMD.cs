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
        public PlayerCMD(string name) : base(name)
        {
        }

        public void ToConsole()
        {
            Console.WriteLine($"Ваше имя - {UserName} имеете {Money} монет.");
        }
    }
}
