using Checkers.BL.Model.Interfaces;
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
       /// <summary>
       /// Конструктор.
       /// </summary>
       /// <param name="name">Имя игрока</param>
       /// <param name="goesForward">Ходит вперед?</param>
        public SimplePlayer(string name, bool goesForward)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Имя игрока не должно быть пустым! ({name})", nameof(name));
            }

            Name = name;
            GoesForward = goesForward;
        }
        /// <summary>
        /// ID игрока.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Куда ходит игрок вперед или назад. Черные вперед белые назад
        /// </summary>
        public bool GoesForward { get; }

    }
}
