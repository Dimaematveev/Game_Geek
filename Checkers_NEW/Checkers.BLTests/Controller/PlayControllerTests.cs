using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.BL.Model.Interfaces;

namespace Checkers.BLTests.Controller
{
    [TestClass()]
    public class PlayControllerTests
    {
        [TestMethod()]
        public void ConstructorNotParam_CreateClass()
        {
            PlayController playController = new PlayController();

            PrivateObject privateObject = new PrivateObject(playController);

            IBoard[] boards = new IBoard[]
            {
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
            };

            privateObject.Invoke("BoardClear");

            IBoard board = (IBoard)(privateObject.GetFieldOrProperty("Board"));

            for (int i = 1; i <= board.Size; i++)
            {
                Assert.AreEqual(boards[i-1], board[i]);
            }
          
        }

        [TestMethod()]
        public void ConstructorNotParam_CreateClass1()
        {
            PlayController playController = new PlayController();

            PrivateObject privateObject = new PrivateObject(playController);

            privateObject.Invoke("BoardClear");
            privateObject.Invoke("BoardFilling", 3);

            IBoard board = (IBoard)(privateObject.GetFieldOrProperty("Board"));
            IBoard[] boards = new IBoard[]
            {
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
            };
            for (int i = 1; i <= board.Size; i++)
            {
                Assert.AreEqual(null, board[i]);
            }
        }
    }
}