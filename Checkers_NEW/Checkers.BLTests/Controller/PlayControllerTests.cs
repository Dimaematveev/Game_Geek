using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkers.BL.Model.Interfaces;
using FakeItEasy;

namespace Checkers.BLTests.Controller
{
    [TestClass()]
    public class PlayControllerTests
    {
        [TestMethod()]
        public void PrivateBoardClear_EqualTrue()
        {
            PlayController playController = new PlayController();

            PrivateObject privateObject = new PrivateObject(playController);

            ICheckersCell[] checkersCell = new ICheckersCell[]
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
                Assert.AreEqual(checkersCell[i-1], board[i]);
            }
          
        }

        [TestMethod()]
        public void PrivateBoardFilling_EqualTrue()
        {
            PlayController playController = new PlayController();

            PrivateObject privateObject = new PrivateObject(playController);

            privateObject.Invoke("BoardClear");

            privateObject.Invoke("BoardFilling", 2);

            IBoard board = (IBoard)(privateObject.GetFieldOrProperty("Board"));
            IPlayer whitePlayer = (IPlayer)(privateObject.GetFieldOrProperty("WhitePlayer"));
            IPlayer blackPlayer = (IPlayer)(privateObject.GetFieldOrProperty("BlackPlayer"));
            IPiece[] pieces = (IPiece[])(privateObject.GetFieldOrProperty("Pieces"));

            ICheckersCell checkersCellWhite =  A.Fake<ICheckersCell>();
            A.CallTo(()=> checkersCellWhite.Player).Returns(whitePlayer);
            A.CallTo(()=> checkersCellWhite.Piece).Returns(pieces[0]);

            ICheckersCell checkersCellBlack = A.Fake<ICheckersCell>();
            A.CallTo(() => checkersCellBlack.Player).Returns(blackPlayer);
            A.CallTo(() => checkersCellBlack.Piece).Returns(pieces[0]);

            ICheckersCell[] checkersCell = new ICheckersCell[]
            {
                checkersCellWhite, checkersCellWhite,checkersCellWhite, checkersCellWhite,
                checkersCellWhite, checkersCellWhite,checkersCellWhite, checkersCellWhite,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                null, null,null, null,
                checkersCellBlack, checkersCellBlack,checkersCellBlack, checkersCellBlack,
                checkersCellBlack, checkersCellBlack,checkersCellBlack, checkersCellBlack,
            };
            for (int i = 1; i <= board.Size; i++)
            {
                if (checkersCell[i - 1] == null || board[i] == null)
                {
                    Assert.AreEqual(checkersCell[i - 1], board[i], $"\ni={i} \nnull ");
                }
                else
                {
                    Assert.AreEqual(checkersCell[i - 1].Player.Name, board[i].Player.Name, $"\ni={i} \nPlayer ");
                    Assert.AreEqual(checkersCell[i - 1].Piece.Name, board[i].Piece.Name, $"\ni={i} \nPiece ");
                }
               
            }
        }
    }
}