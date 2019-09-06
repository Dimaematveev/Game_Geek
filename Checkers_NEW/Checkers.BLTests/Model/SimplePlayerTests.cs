using System;
using Checkers.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.BLTests.Model
{
    [TestClass]
    public class SimplePlayerTests
    {
        [TestMethod]
        public void ConstructorOneParam_NameNotNull_CreateClass()
        {
            string name = Guid.NewGuid().ToString().Substring(1, 6);
            SimplePlayer simplePlayer = new SimplePlayer(name);
        }

        [TestMethod]
        public void ConstructorOneParam_NameNull_CreateClass()
        {
            string name1 = null;
            string name2 = "";
            string name3 = "     ";
            string name4 = "   \t ";

            Assert.ThrowsException<ArgumentNullException>(() => new SimplePlayer(name1), "name=NULL");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePlayer(name2), "name='' ");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePlayer(name3), "name='  ' ");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePlayer(name4), "name='  \\t ' ");
        }
    }
}
