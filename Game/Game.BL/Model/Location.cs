using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    /// <summary>
    /// Локация. 
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Название локации.
        /// </summary>
        protected string LocationName { get; }

        public Location(string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                throw new ArgumentNullException("Имя локации не может быть пустым!!", nameof(locationName));
            }
          
            LocationName = locationName;
        }

    }
}
