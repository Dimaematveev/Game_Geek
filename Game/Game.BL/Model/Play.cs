using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    /// <summary>
    /// Игра.
    /// </summary>
    public class Play
    {
        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        protected readonly User CurrentUser;
        /// <summary>
        /// Текущая локация.
        /// </summary>
        public Location CurrentLocation { get; private set; }

        public Play(User currentUser, Location currentLocation)
        {
            if (currentUser==null)
            {
                throw new ArgumentNullException("Пользователь не должен быть пустым!", nameof(currentUser));
            }
            if (currentLocation == null)
            {
                throw new ArgumentNullException("Локация не должна быть пустой!", nameof(currentLocation));
            }
            CurrentUser = currentUser;
            NewLocation(currentLocation);
            CurrentLocation = currentLocation;
        }

        public void ChangeLocation(Location newLocation)
        {
            ExitLocation();
            NewLocation(newLocation);
        }

        private void ExitLocation()
        {
            if (CurrentLocation == null)
            {
                throw new ArgumentException("Текущая локация уже пуста!", nameof(CurrentLocation));
            }
            CurrentLocation = null;
        }
        private void NewLocation(Location newLocation)
        {
            if (CurrentLocation!=null)
            {
                throw new ArgumentException("Текущая локация должна быть пустой!", nameof(CurrentLocation));
            }
            if (newLocation == null)
            {
                throw new ArgumentNullException("Новая локация не должна быть пустой!", nameof(newLocation));
            }
            CurrentLocation = newLocation;
        }
    }
}
