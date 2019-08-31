using Game.BL.Controller;
using Game.BL.Controller.LocationsControllerOptions;
using Game.BL.Controller.ProductsControllerOptions;
using Game.BL.Model;
using Game.BL.Model.LocationsOptions;
using Game.CMD.Interface;
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
            List<Location> locations = new List<Location>();

            List<HomeCMD> home = new List<HomeCMD>
            {
                new HomeCMD("Дом 1 простой."),
                new HomeCMD("Дом 2 улучшенный."),
                new HomeCMD("Дом 3 модный."),
                new HomeCMD("Дом 4 элитный.")
            };
            List<ShopCMD> shops = new List<ShopCMD>
            {
                new ShopCMD("Магазин 1"),
                new ShopCMD("Магазин 2")
            };
            
            locations.AddRange(home);
            locations.AddRange(shops);
            HomeController homeController = new HomeController(home.ToArray());
            List<Product> products = new List<Product>
            {
                new MouseCMD("Мышь1",10),
                new MouseCMD("Мышь2",20),
                new MouseCMD("Мышь3",11),
                new MouseCMD("Мышь4",8),
                new KeyboardCMD("Клавиатура1",8),
                new KeyboardCMD("Клавиатура2",16),
                new KeyboardCMD("Клавиатура3",2),
                new KeyboardCMD("Клавиатура4",123),
            };
            foreach (var shop in shops)
            {
                foreach (var product in products)
                {
                    shop.Add(product);
                }
            }
            
            // MouseController mouseController = new MouseController(products.ToArray());

            //ProductController productController = new ProductController(products.ToArray());

            ShopController shopController = new ShopController(shops.ToArray(), shops[0]);
            PlayerCMD player = new PlayerCMD("Dima",(HomeCMD)(homeController.CurrentLocation));
            

            PlayCMD play = new PlayCMD(player, player.CurrentHome);
            play.ToConsole(3);

            Console.WriteLine();
            Console.WriteLine("Вы можете сменить локацию на:");
          
            {
                int numLoc = -1;
                int i = 0;
                foreach (var location in locations)
                {
                    Console.WriteLine($"Введите {i++} для выбора этой локации!");
                    ((IConsole)location).ToConsole(3);
                }
                Console.WriteLine();
                while (!(int.TryParse(Console.ReadLine(), out numLoc)) || numLoc > i || numLoc<0)
                {
                    Console.WriteLine("Неверно ввели! Повторите ввод!");
                }
                play.ChangeLocation(locations[numLoc]);
            }
            if( play.CurrentLocation is Shop)
            {
                Console.WriteLine("Вы в магазине");

                Console.WriteLine("Можно купить:");

                ((ShopCMD)play.CurrentLocation).Price(3);
            }
            
            

            Console.ReadLine();
        }
    }
}
