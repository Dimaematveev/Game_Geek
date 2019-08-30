using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    class LocationCMD : Location, IConsole
    {
        public LocationCMD(string locationName,User user) : base(locationName,user)
        {
        }

        public void ToConsole()
        {
            throw new NotImplementedException();
        }
    }
}
