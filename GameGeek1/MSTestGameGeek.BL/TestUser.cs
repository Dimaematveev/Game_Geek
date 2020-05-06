using GameGeek.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

            Assert.AreEqual(user.Name, name);
            Assert.AreEqual(user.Money, 100);
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


        /// <summary>
        /// Проверяем максимальная длинна имени 20
        /// </summary>
        [TestMethod]
        public void IsMaxNameLength20_MaxNameLength_True()
        {
            Assert.AreEqual(User.MaxNameLength, 20);
        }

        /// <summary>
        /// Проверяем разрешенные символы
        /// </summary>
        [TestMethod]
        public void IsAllowedSymbolsInName_AllowedSymbolsInName_True()
        {
            Assert.AreEqual(User.AllowedSymbolsInName, "abcdefghijklmnopqrstuvwxyzабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789 ");
        }

        /// <summary>
        /// Проверяем Изменение кол-во денег и сработку События
        /// </summary>
        [DataTestMethod]
        [DataRow(50)]
        [DataRow(100)]
        [DataRow(129)]
        [DataRow(-400)]
        public void IsEditMoneyAndEvensNotifyAmountOfMoneyChanged_EditMoney_True(int edit)
        {
            bool called = false;
            User user = new User("Daad");
            user.NotifyAmountOfMoneyChanged += (str) => called = true;
            user.EditMoney(edit);



            // assert
            Assert.AreEqual(user.Money, 100+edit);
            Assert.IsTrue(called,$"called будет True если вызовется событие изменения кол-ва денег, сейчас called={called}");

        }
    }
}
