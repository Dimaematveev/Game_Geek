using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGeek.BL
{
    public class User
    {
        /// <summary>  Разрешенные символы в имени  </summary>
        private readonly static string allowedSymbolsInName = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ";
        /// <summary> Максимальное кол-во символов в имени </summary>   
        private readonly static int maxNameLength = 20;
        /// <summary>  Имя пользователя  </summary>
        public string Name { get; private set; }
        /// <summary>  Разрешенные символы в имени  </summary>
        public static string AllowedSymbolsInName => allowedSymbolsInName;
        /// <summary> Максимальное кол-во символов в имени </summary>
        public static int MaxNameLength => maxNameLength;

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name),$"Имя пользователя: [{name}], не должно быть пустым или содержать только символы разделители!");
            }
            if (!IsSymbolAllowed(name))
            {
                throw new ArgumentException(nameof(name), $"Имя пользователя: [{name}], содержит неразрешенные символы! Список разрешенных: [{AllowedSymbolsInName}]!");
            }
            if (name.Length > MaxNameLength)
            {
                throw new ArgumentException(nameof(name), $"Имя пользователя: [{name}], количество символов не должно быть больше {MaxNameLength}, у вас {name.Length}!");
            }
            Name = name;
        }

        /// <summary>
        /// Разрешен ли символ, только маленькие буквы,  регистр не учитывается, можно и большие и маленькие
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public static bool IsSymbolAllowed(char ch)
        { 
            return AllowedSymbolsInName.Contains(ch.ToString().ToLower());
        }

        /// <summary>
        /// Разрешены ли символы из строки,  регистр не учитывается, можно и большие и маленькие
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSymbolAllowed(string str)
        {
            return str.All(x => IsSymbolAllowed(x));
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is User objUser)
            {
                return objUser.Name.Equals(Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
