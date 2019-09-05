using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    public class SimplePlayer : IPlayer
    {
        public SimplePlayer(string name)
        {
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

    }
}
