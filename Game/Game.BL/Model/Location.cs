using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class Location
    {
        private string LocationName { get; }
        private User User { get; }

        public Location(string locationName, User user)
        {
            if (string.IsNullOrWhiteSpace(locationName))
            {
                throw new ArgumentNullException("Имя локации не может быть пустым!!", nameof(locationName));
            }
            if (user==null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!!", nameof(user));
            }

            LocationName = locationName;
            User = user;
        }

    }
}
