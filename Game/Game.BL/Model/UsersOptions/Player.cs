using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL.Model.UsersOptions
{
    /// <summary>
    /// Игрок!
    /// </summary>
    public class Player : User
    {
        /// <summary>
        /// Количество денег!
        /// </summary>
        protected int Money { get; set; }
        public Player(string name) : base(name)
        {
            Money = 200;
        }
    }
}
