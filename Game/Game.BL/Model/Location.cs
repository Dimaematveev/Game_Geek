using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class Location
    {
        protected string LocationName { get; }
        protected User CurrentUser { get; }

        public Location(string locationName, User currentUser)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                throw new ArgumentNullException("Имя локации не может быть пустым!!", nameof(locationName));
            }
            if (currentUser == null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!!", nameof(currentUser));
            }

            LocationName = locationName;
            CurrentUser = currentUser;
        }

    }
}
