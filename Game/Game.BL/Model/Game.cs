using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class Game
    {
       
        private User User { get; }

        public Game(User user)
        {
            if (user==null)
            {
                throw new ArgumentNullException("Пользователь не может быть пустым!!", nameof(user));
            }
            User = user;
        }

    }
}
