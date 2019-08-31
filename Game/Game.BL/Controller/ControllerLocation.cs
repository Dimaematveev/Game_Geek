using Game.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Controller
{
    public class ControllerLocation
    {
        protected readonly Location[] Locations;
        public Location CurrentLocation { get; private set; }
        public ControllerLocation(Location[] locations, Location currentLocation)
        {
            if (locations==null || locations.Length==0)
            {
                throw new ArgumentNullException("Список локаций не должен быть пустым!", nameof(locations));
            }
            if (currentLocation == null )
            {
                throw new ArgumentNullException("Текущая локация не должна быть пустой!", nameof(currentLocation));
            }
            Locations = locations;
            CurrentLocation=currentLocation;
        }
    }
}
