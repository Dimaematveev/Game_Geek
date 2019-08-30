using Game.CMD.Model;
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
            UserCMD user = new UserCMD("Dima");

            LocationCMD location = new LocationCMD("Loc1", user);


            Console.ReadLine();
        }
    }
}
