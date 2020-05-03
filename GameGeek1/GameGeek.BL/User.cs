using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGeek.BL
{
    public class User
    {
        /// <summary>
        /// Разрешенные символы в имени
        /// </summary>
        private static string AllowedCharactersWithName= "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ";
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; private set; }


        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name),$"Имя пользователя: [{name}], не должно быть пустым или содержать только символы разделители!");
            }
            if (!name.ToLower().All(x=> AllowedCharactersWithName.Contains(x)))
            {
                throw new ArgumentException(nameof(name), $"Имя пользователя: [{name}], содержит неразрешенные символы! Список разрешенных: [{AllowedCharactersWithName}]!");
            }
            Name = name;
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
