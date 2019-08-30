using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    public class User
    {
        private string UserName {get; }
        private int Count { get; set; }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!!", nameof(name));
            }

            UserName = name;
            Count = 200;
        }



    }
}
