using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model
{
    /// <summary>
    /// Пользователь!
    /// </summary>
    public class User
    {
        /// <summary>
        /// Имя пользователя!
        /// </summary>
        protected string UserName {get; }
       

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым!!", nameof(name));
            }

            UserName = name;
        }



    }
}
