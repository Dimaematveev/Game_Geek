using System;
using System.Reflection;
using GameGeek.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestGameGeek.BL
{
    [TestClass]
    public class TestWork
    {
        /// <summary>
        /// Пустые строчки в имени, вывод исключение ArgumentNullException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("",1)]
        [DataRow("   ",-1)]
        [DataRow("\t\n",0)]
        [DataRow("\n",100)]
        public void Constructor_NullOrWhiteSpaceName_ArgumentNullException(string name,int salary)
        {
            var errorMess = Assert.ThrowsException<ArgumentNullException>(()=>new Work(name,salary),$"Строка [{name}], является пустой, но исключение не дает");
            Assert.AreEqual(errorMess.ParamName, nameof(Work.Name),$"Этот метод тестирует исключение на Название");
        }


        /// <summary>
        /// Разрешенные имена, создается класс
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("Work1",1)]
        [DataRow("Работа1",109)]
        [DataRow("Прогер",29134)]
        [DataRow("кОлЯн 7777",127)]
        public void Constructor_NameIsOk_CreateClassWork(string name, int salary)
        {
            Work Work = new Work(name,salary);

            Assert.AreEqual(Work.Name, name);
            Assert.AreEqual(Work.SalaryToDay, salary);
        }


        /// <summary>
        /// Запрещенные символы, вывод исключение ArgumentException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("Ivan!",1)]
        [DataRow("~32ffe",-1)]
        [DataRow("Оле-Коле",0)]
        [DataRow("кОлЯн}",10833)]
        
        public void Constructor_NameIsNotOkАorbiddenCharacters_ArgumentException(string name,int salary)
        {
            var errorMess = Assert.ThrowsException<ArgumentException>(() => new Work(name, salary));
            Assert.AreEqual(errorMess.ParamName, nameof(Work.Name), $"Этот метод тестирует исключение на Название");
        }

        /// <summary>
        /// Зарплата меньше равна 0, вывод исключение ArgumentException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("Ivan13", -211)]
        [DataRow("32ffe", -1)]
        [DataRow("ОлеКоле", 0)]
        [DataRow("кОлЯн", -3248)]

        public void Constructor_SalaryIsNotOkLessNull_ArgumentException(string name, int salary)
        {
            var errorMess = Assert.ThrowsException<ArgumentException>(() => new Work(name, salary));
            Assert.AreEqual(errorMess.ParamName, nameof(Work.SalaryToDay), $"Этот метод тестирует исключение на Зарплату");
        }

        /// <summary>
        /// Слишком длинные имена, вывод исключение ArgumentException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("IvanIvanIvanIvanIvan1",100)]
        [DataRow("Вырованцева Кристина Александровна",190)]
        public void Constructor_NameIsNotOk_ArgumentException(string name,int salary)
        {
            var errorMess = Assert.ThrowsException<ArgumentException>(() => new Work(name, salary));
            Assert.AreEqual(errorMess.ParamName, nameof(Work.Name), $"Этот метод тестирует исключение на Название");
        }


        /// <summary>
        /// Проверяем что эти символы можно написать в Имени, возвращает true
        /// </summary>
        /// <param name="str"></param>
        [DataTestMethod]
        [DataRow("InfJdhwОВдвт0976")]
        [DataRow("рпроОРРпв73аощРцвд")]
        public void IsSymbolAllowed_StringSymbolsIsAllowed_True(string str)
        {
            Assert.IsTrue(Work.IsSymbolAllowed(str));
        }

        /// <summary>
        /// Проверяем что эти символы можно написать в Имени, возвращает False
        /// </summary>
        /// <param name="str"></param>
        [DataTestMethod]
        [DataRow("121_33")]
        [DataRow("121+33")]
        [DataRow("  d ~")]
        public void IsSymbolAllowed_StringSymbolsIsAllowed_False(string str)
        {
            Assert.IsFalse(Work.IsSymbolAllowed(str));
        }



        /// <summary>
        /// Проверяем что этот символ можно написать в Имени, возвращает true
        /// </summary>
        /// <param name="ch"></param>
        [DataTestMethod]
        [DataRow('1')]
        [DataRow('D')]
        [DataRow('d')]
        [DataRow('И')]
        [DataRow('й')]
        [DataRow('ё')]
        [DataRow('Ё')]
        public void IsSymbolAllowed_SymbolIsAllowed_True(char ch)
        {
            Assert.IsTrue(Work.IsSymbolAllowed(ch));
        }

        /// <summary>
        /// Проверяем что этот символ можно написать в Имени, возвращает False
        /// </summary>
        /// <param name="ch"></param>
        [DataTestMethod]
        [DataRow('!')]
        [DataRow('_')]
        [DataRow('=')]
        [DataRow('~')]
        public void IsSymbolAllowed_SymbolIsAllowed_False(char ch)
        {
            Assert.IsFalse(Work.IsSymbolAllowed(ch));
        }


        /// <summary>
        /// Проверяем максимальная длинна имени 20
        /// </summary>
        [TestMethod]
        public void IsMaxNameLength20_MaxNameLength_True()
        {
            Assert.AreEqual(Work.MaxNameLength, 20);
        }

        /// <summary>
        /// Проверяем разрешенные символы
        /// </summary>
        [TestMethod]
        public void IsAllowedSymbolsInName_AllowedSymbolsInName_True()
        {
            Assert.AreEqual(Work.AllowedSymbolsInName, "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ");
        }

       
    }
}
