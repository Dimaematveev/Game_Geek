using System;
using GameGeek.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTestGameGeek.BL
{
    [TestClass]
    public class TestUser
    {
        [DataTestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow("\t\n")]
        [DataRow("\n")]
        public void Constructor_NullOrWhiteSpaceName_ArgumentNullException(string name)
        {
            Assert.ThrowsException<ArgumentNullException>(()=>new User(name));
        }

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

        [DataTestMethod]
        [DataRow("Ivan!")]
        [DataRow("~32ffe")]
        [DataRow("Оле-Коле")]
        [DataRow("кОлЯн}")]
        public void Constructor_NameIsNotOk_ArgumentException(string name)
        {
            Assert.ThrowsException<ArgumentException>(() => new User(name));
        }
    }
}
