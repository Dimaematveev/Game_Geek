using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.BL.Model;
using Game.BL.Model.LocationsOptions;

namespace Game.BL.Controller.LocationsControllerOptions
{
    public class HomeController : ControllerLocation
    {
        public HomeController(Home[] homes):base(homes, homes[0])
        {
           
        }

    }
}
