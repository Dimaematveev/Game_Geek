using System;
using System.Collections.Generic;
using Checkers.BL.Model;
using Checkers.BL.Model.Interfaces;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checkers.BLTests.Model
{
    [TestClass]
    public class SimplePieceTests
    {
        [TestMethod]
        public void ConstructorTwoParam_NameNotNullHowMovesLengMore0_CreateClass()
        {
            string name = Guid.NewGuid().ToString().Substring(0, 6);
            IEnumerable<IHowMove> howMove = new List<IHowMove>
            {
                A.Fake<IHowMove>()
            };
            SimplePiece simplePiece = new SimplePiece(name, howMove);
            
           
        }
        [TestMethod]
        public void ConstructorTwoParam_NameNullHowMovesLengMore0_ArgumentNullException()
        {
            string name1 = null;
            string name2 = "";
            string name3 = "     ";
            string name4 = "   \t ";
            IEnumerable<IHowMove> howMove = new List<IHowMove>
            {
                A.Fake<IHowMove>()
            };
           
           Assert.ThrowsException<ArgumentNullException>(()=> new SimplePiece(name1, howMove), "name=NULL howMove.leng=1");
           Assert.ThrowsException<ArgumentNullException>(()=> new SimplePiece(name2, howMove), "name='' howMove.leng=1");
           Assert.ThrowsException<ArgumentNullException>(()=> new SimplePiece(name3, howMove), "name='  ' howMove.leng=1");
           Assert.ThrowsException<ArgumentNullException>(()=> new SimplePiece(name4, howMove), "name='  \\t ' howMove.leng=1");
        }


        [TestMethod]
        public void ConstructorTwoParam_NameNotNullHowMovesLeng0OrNull_ArgumentNullException()
        {
            string name = Guid.NewGuid().ToString().Substring(0, 6);
            IEnumerable<IHowMove> howMove1 = new List<IHowMove>();
            IEnumerable<IHowMove> howMove2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name, howMove1), "name=GUID howMove.leng=0");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name, howMove2), "name=GUID howMove=null");
        }

        [TestMethod]
        public void ConstructorTwoParam_NameNullHowMovesLeng0OrNull_ArgumentNullException()
        {
            string name1 = null;
            string name2 = "";
            string name3 = "     ";
            string name4 = "   \t ";
            IEnumerable<IHowMove> howMove1 = new List<IHowMove>();
            IEnumerable<IHowMove> howMove2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name1, howMove1), "name=NULL howMove.leng=0");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name1, howMove2), "name=NULL howMove=null");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name2, howMove1), "name='' howMove.leng=0");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name2, howMove2), "name='' howMove=null");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name3, howMove1), "name='  ' howMove.leng=0");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name3, howMove2), "name='  ' howMove=null");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name4, howMove1), "name='  \\t ' howMove.leng=0");
            Assert.ThrowsException<ArgumentNullException>(() => new SimplePiece(name4, howMove2), "name='  \\t ' howMove=null");
        }
    }
}
