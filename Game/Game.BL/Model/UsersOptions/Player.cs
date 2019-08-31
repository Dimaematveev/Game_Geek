using Game.BL.Model.LocationsOptions;
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
        protected int Money { get; private set; }
        /// <summary>
        /// Дом в котором сейчас живет!
        /// </summary>
        public Home CurrentHome { get; private set; }
        public Player(string name, Home currentHome) : base(name)
        {
            Money = 200;
            CurrentHome = currentHome;
        }
    }
}
