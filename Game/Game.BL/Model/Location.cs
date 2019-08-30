using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class Location
    {
       
        private User User { get; }

        public Location(User user)
        {
            if (user==null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!!", nameof(user));
            }
            User = user;
        }

    }
}
