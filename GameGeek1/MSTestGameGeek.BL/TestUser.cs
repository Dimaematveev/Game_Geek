using System;
using GameGeek.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestGameGeek.BL
{
    [TestClass]
    public class TestUser
    {
        /// <summary>
        /// Пустые строчки в имени, вывод исключение ArgumentNullException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\t\n")]
        [DataRow("\n")]
        public void Constructor_NullOrWhiteSpaceName_ArgumentNullException(string name)
        {
            Assert.ThrowsException<ArgumentNullException>(()=>new User(name));
        }


        /// <summary>
        /// Разрешенные имена, создается класс
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("Ivan1")]
        [DataRow("Иван1")]
        [DataRow("Ваня")]
        [DataRow("кОлЯн 7777")]
        public void Constructor_NameIsOk_CreateClassUser(string name)
        {
            User user = new User(name);

            Assert.AreEqual(name,user.Name);
        }


        /// <summary>
        /// Запрещенные символы, вывод исключение ArgumentException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("Ivan!")]
        [DataRow("~32ffe")]
        [DataRow("Оле-Коле")]
        [DataRow("кОлЯн}")]
        
        public void Constructor_NameIsNotOkАorbiddenCharacters_ArgumentException(string name)
        {
            Assert.ThrowsException<ArgumentException>(() => new User(name));
        }

        /// <summary>
        /// Слишком длинные имена, вывод исключение ArgumentException
        /// </summary>
        /// <param name="name"></param>
        [DataTestMethod]
        [DataRow("IvanIvanIvanIvanIvan1")]
        [DataRow("Вырованцева Кристина Александровна")]
        public void Constructor_NameIsNotOk_ArgumentException(string name)
        {
            Assert.ThrowsException<ArgumentException>(() => new User(name));
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
            Assert.IsTrue(User.IsSymbolAllowed(str));
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
            Assert.IsFalse(User.IsSymbolAllowed(str));
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
            Assert.IsTrue(User.IsSymbolAllowed(ch));
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
            Assert.IsFalse(User.IsSymbolAllowed(ch));
        }
    }
}
