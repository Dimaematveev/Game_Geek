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
        protected Location CurrentLocation;

        public Play(User currentUser, Location currentLocation)
        {
            if (currentUser==null)
            {
                throw new ArgumentNullException("Пользователь не должен быть пустым!", nameof(currentUser));
            }
            if (currentLocation == null)
            {
                throw new ArgumentNullException("Локация не должна быть пустым!", nameof(currentLocation));
            }
            CurrentUser = currentUser;
            CurrentLocation = currentLocation;
        }
    }
}
