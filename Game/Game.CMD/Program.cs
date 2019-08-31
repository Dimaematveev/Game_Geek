using Game.CMD.Model;
using Game.CMD.Model.LocationsOptions;
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

            List<HomeCMD> Home = new List<HomeCMD>
            {
                new HomeCMD("Дом 1 простой."),
                new HomeCMD("Дом 2 улучшенный."),
                new HomeCMD("Дом 3 модный."),
                new HomeCMD("Дом 4 элитный.")
            };

            PlayCMD play = new PlayCMD(user, Home[0]);
            play.ToConsole();
            play.ChangeLocation(Home[1]);
            play.ToConsole();

            Console.ReadLine();
        }
    }
}
