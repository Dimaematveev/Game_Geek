using System;
using Checkers.BL.Model;
using Checkers.BL.Model.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.BLTests.Model
{
    [TestClass]
    public class SimpleCheckersCellTests
    {
        [TestMethod]
        public void ConstructorTwoParam_PlayerAndPieceNotNULL_CreateClass()
        {
            var player = A.Fake<IPlayer>();
            var piece = A.Fake<IPiece>();

            SimpleCheckersCell simpleCheckersCellTests = new SimpleCheckersCell(player, piece);

        }
        [TestMethod]
        public void ConstructorTwoParam_PlayerAndPieceNULL_ArgumentException()
        {
            IPlayer player =null;
            IPiece piece = null;

            Assert.ThrowsException<ArgumentException>(()=> new SimpleCheckersCell(player, piece));

        }
        [TestMethod]
        public void ConstructorTwoParam_PlayerOrPieceNULL_ArgumentException()
        {
            IPlayer player1 = A.Fake<IPlayer>();
            IPiece piece1 = null;
            IPlayer player2 = null;
            IPiece piece2 = A.Fake<IPiece>();
            Assert.ThrowsException<ArgumentException>(() => new SimpleCheckersCell(player1, piece1), $"\nplayer=null \npiece=Fake");

            Assert.ThrowsException<ArgumentException>(() => new SimpleCheckersCell(player2, piece2), $"\nplayer=Fake \npiece=null");

        }
    }
}
