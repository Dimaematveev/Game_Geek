﻿using Game.BL.Model;
using Game.CMD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CMD.Model
{
    class GameCMD : Location, IConsole
    {
        public GameCMD(User user) : base(user)
        {
        }

        public void ToConsole()
        {
            throw new NotImplementedException();
        }
    }
}
