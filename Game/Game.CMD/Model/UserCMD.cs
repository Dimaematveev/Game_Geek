using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    class UserCMD : User, IConsole
    {
        public UserCMD(string name) : base(name)
        {
        }

        public void ToConsole(int spaceLeft)
        {
            Console.CursorLeft = spaceLeft;
            Console.WriteLine($"Ваше имя - {UserName}.");
        }
    }
}
