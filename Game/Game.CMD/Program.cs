using Game.CMD.Model;
using Game.CMD.Model.UsersOptionsCMD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCMD user = new PlayerCMD("Dima");

            LocationCMD location = new LocationCMD("Loc1");

            PlayCMD play = new PlayCMD(user, location);
            play.ToConsole();

            Console.ReadLine();
        }
    }
}
