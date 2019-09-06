using System;
using Checkers.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.BLTests.Model
{
    [TestClass]
    public class SimpleHowMoveTests
    {
        [TestMethod]
        public void ConstructorTwoParam_RowColumn_CreateClass()
        {
            Random rnd = new Random();
            int row = 0;
            int column = 0;
            for (int i = 0; i < 100; i++)
            {
                row = rnd.Next(-100, 100);
                column = rnd.Next(-100, 100);
                SimpleHowMove simpleHowMove = new SimpleHowMove(row, column);
            }
           
        }
    }
}
