using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGeek.BL
{
    public class Work
    {
        /// <summary>  Разрешенные символы в названии работы   </summary>
        private readonly static string allowedSymbolsInName = "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ";
        /// <summary> Максимальное кол-во символов в названии работы  </summary>   
        private readonly static int maxNameLength = 20;
        /// <summary>  Название работы  </summary>
        private readonly string name;
        /// <summary>  Зарплата за 1 день </summary>
        private readonly int salaryToDay;
        /// <summary>  Название работы  </summary>
        /// 

        public string Name => name;
        /// <summary>  Зарплата за 1 день </summary>
        public int SalaryToDay => salaryToDay;

        /// <summary>  Разрешенные символы в названии работы  </summary>
        public static string AllowedSymbolsInName => allowedSymbolsInName;
        /// <summary> Максимальное кол-во символов в названии работы  </summary>
        public static int MaxNameLength => maxNameLength;

        public Work(string name, int salaryToDay)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(Name), $"Название работы: [{name}], не должно быть пустым или содержать только символы разделители!");
            }
            if (!IsSymbolAllowed(name))
            {
                throw new ArgumentException($"Названии работы : [{name}], содержит неразрешенные символы! Список разрешенных: [{AllowedSymbolsInName}]!", nameof(Name));
            }
            if (name.Length > MaxNameLength)
            {
                throw new ArgumentException($"Названии работы : [{name}], количество символов не должно быть больше {MaxNameLength}, у вас {name.Length}!", nameof(Name));
            }
            if (salaryToDay <= 0) 
            {
                throw new ArgumentException($"Зарплата за 1 день: [{salaryToDay}], должна быть не меньше 0!", nameof(SalaryToDay));
            }
            this.name = name;
            this.salaryToDay = salaryToDay;
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





        //ToDO:Не тестировал
        public override string ToString()
        {
            return $"Name:{Name}, Salary To Day:{SalaryToDay}";
        }
        //ToDO:Не тестировал
        public override bool Equals(object obj)
        {
            if (obj is Work objWork)
            {
                bool res = true;
                res = res && objWork.Name.Equals(Name);
                res = res && objWork.SalaryToDay.Equals(SalaryToDay);

                return res;
            }
            return false;
        }
        //ToDO:Не тестировал
        public override int GetHashCode()
        {
            int hash = Name.ToString().GetHashCode();
            return hash;
        }

    }
}
