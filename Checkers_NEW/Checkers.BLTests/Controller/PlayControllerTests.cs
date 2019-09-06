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

            (void)privateObject.Invoke("BoardFilling", 0);

            IPiece[] pieces = (IPiece[])(privateObject.GetFieldOrProperty("Pieces"));

            foreach (var piece in pieces)
            {
                Assert.AreEqual(piece, null);
            }
        }
    }
}