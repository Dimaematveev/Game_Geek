﻿using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Model
{
    /// <summary>
    /// Игрок.
    /// </summary>
    public class SimplePlayer : IPlayer
    {
        public SimplePlayer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Имя игрока не должно быть пустым! ({name})", nameof(name));
            }

            Name = name;
        }
        /// <summary>
        /// ID игрока.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; }

    }
}
