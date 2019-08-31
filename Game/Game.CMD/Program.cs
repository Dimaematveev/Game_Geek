using Game.BL.Controller.LocationsControllerOptions;
using Game.BL.Controller.ProductsControllerOptions;
using Game.BL.Model;
using Game.CMD.Model;
using Game.CMD.Model.LocationsOptions;
using Game.CMD.Model.ProductsOptions;
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
            

            List<HomeCMD> Home = new List<HomeCMD>
            {
                new HomeCMD("Дом 1 простой."),
                new HomeCMD("Дом 2 улучшенный."),
                new HomeCMD("Дом 3 модный."),
                new HomeCMD("Дом 4 элитный.")
            };
            HomeController homeController = new HomeController(Home.ToArray());
            List<Product> products = new List<Product>
            {
                new MouseCMD("Мышь1",10),
                new MouseCMD("Мышь2",20),
                new MouseCMD("Мышь3",11),
                new MouseCMD("Мышь4",8),
            };
            MouseController mouseController = new MouseController(products.ToArray());
            PlayerCMD player = new PlayerCMD("Dima",(HomeCMD)(homeController.CurrentLocation));
            

            PlayCMD play = new PlayCMD(player, player.CurrentHome);
            play.ToConsole(3);
            play.ChangeLocation(Home[1]);
            play.ToConsole(3);

            Console.ReadLine();
        }
    }
}
