using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BLTests.Model
{
    [TestClass()]
    public class SimpleBoardTests
    {
        [TestMethod()]
        public void ConstructorTwoParam_RowColumIsEvenAndMoreThan0_CreateClass()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int row = rnd.Next(1, 25) * 2;
                int column = rnd.Next(1, 25) * 2;
                SimpleBoard simpleBoard = new SimpleBoard(row, column);
                Assert.IsNotNull(simpleBoard);
            }
            
        }
        [TestMethod()]
        public void ConstructorTwoParam_RowColumIsEvenAndLessThan0_ArgumentException()
        {
            Random rnd = new Random();
            int row = 0;
            int column = 0;
            for (int i = 0; i < 100; i++)
            {
                Assert.ThrowsException<ArgumentException>(()=>new SimpleBoard(row, column),$"\ni='{i}' \nrow = '{row}' \ncolumn = '{column}'");
                row = rnd.Next(-25, 0) * 2;
                column = rnd.Next(-25, 0) * 2;
            }

        }
        [TestMethod()]
        public void ConstructorTwoParam_RowColumIsOddAndMoreThan0_ArgumentException()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int row = rnd.Next(1, 25) * 2 - 1;
                int column = rnd.Next(1, 25) * 2 - 1 ;
                Assert.ThrowsException<ArgumentException>(() => new SimpleBoard(row, column), $"\ni='{i}' \nrow = '{row}' \ncolumn = '{column}'");
                
            }

        }
        [TestMethod()]
        public void ConstructorTwoParam_RowColumIsOddAndLessThan0_ArgumentException()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int row = rnd.Next(-25, 0) * 2 - 1;
                int column = rnd.Next(-25, 0) * 2 - 1;
                Assert.ThrowsException<ArgumentException>(() => new SimpleBoard(row, column), $"\ni='{i}' \nrow = '{row}' \ncolumn = '{column}'");
                
            }

        }

        [TestMethod()]
        public void ConstructorOneParam_NumIsEvenAndMoreThan0_CreateClass()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int num = rnd.Next(1, 25) * 2;
                SimpleBoard simpleBoard = new SimpleBoard(num);
                Assert.IsNotNull(simpleBoard);
            }

        }

        [TestMethod()]
        public void ConstructorOneParam_NumIsEvenAndLessThan0_ArgumentException()
        {
            Random rnd = new Random();
            int num = 0;
            for (int i = 0; i < 100; i++)
            {
                Assert.ThrowsException<ArgumentException>(() => new SimpleBoard(num), $"\ni='{i}' \nnum = '{num}'");
                num = rnd.Next(-25, 0) * 2;
            }

        }
        [TestMethod()]
        public void ConstructorOneParam_NumIsOddAndMoreThan0_ArgumentException()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int num = rnd.Next(1, 25) * 2 - 1;
                Assert.ThrowsException<ArgumentException>(() => new SimpleBoard(num), $"\ni='{i}' \nnum = '{num}'");

            }

        }
        [TestMethod()]
        public void ConstructorOneParam_NumIsOddAndLessThan0_ArgumentException()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int num = rnd.Next(-25, 0) * 2 - 1;
                Assert.ThrowsException<ArgumentException>(() => new SimpleBoard(num), $"\ni='{i}' \nnum = '{num}'");

            }

        }

        [TestMethod()]
        public void ThisOneParam_PositionMore0AndLessSize_ReturnNull()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int position = simpleBoard.Size;
            for (int i = 0; i < 100; i++)
            {
                //
                
                //Assert
                Assert.IsNull(simpleBoard[position]);
                position = rnd.Next(1, simpleBoard.Size);
            }
        }
        [TestMethod()]
        public void ThisOneParam_PositionMoreSize_ArgumentException()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int position = simpleBoard.Size + 1;
            for (int i = 0; i < 100; i++)
            {
                //
                
                //Assert
                Assert.ThrowsException<ArgumentException>(() => simpleBoard[position], $"\ni='{i}' \nposition = '{position}'");
                position = rnd.Next(simpleBoard.Size + 1, simpleBoard.Size + 100);
            }
        }
        [TestMethod()]
        public void ThisOneParam_PositionLess0_ArgumentException()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int position = 0;
            for (int i = 0; i < 100; i++)
            {
                //
               
                //Assert
                Assert.ThrowsException<ArgumentException>(() => simpleBoard[position], $"\ni='{i}' \nposition = '{position}'");
                position = rnd.Next(-50, 0);
            }
        }

        [TestMethod()]
        public void ThisTwoParam_RowColumnMore0AndLessSize_ReturnNull()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int row = simpleBoard.Rows;
            int column = simpleBoard.Columns;
            for (int i = 0; i < 100; i++)
            {
                //Assert
                Assert.IsNull(simpleBoard[row,column]);
                row = rnd.Next(1, simpleBoard.Rows);
                column = rnd.Next(1, simpleBoard.Columns);
            }
        }
        [TestMethod()]
        public void ThisTwoParam_RowColumnMoreSize_ArgumentException()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int row = simpleBoard.Rows+1;
            int column = simpleBoard.Columns+1;
            for (int i = 0; i < 100; i++)
            {
                
                //Assert
                Assert.ThrowsException<ArgumentException>(() => simpleBoard[row, column], $"\ni='{i}' \nrow = '{row}' \ncolumn = '{column}'");
                row = rnd.Next(simpleBoard.Rows + 1, simpleBoard.Rows + 100);
                column = rnd.Next(simpleBoard.Columns + 1, simpleBoard.Columns + 100);
            }
        }
        [TestMethod()]
        public void ThisTwoParam_RowColumnLess0_ArgumentException()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 25) * 2;
            SimpleBoard simpleBoard = new SimpleBoard(num);
            int row = 0;
            int column = 0;
            for (int i = 0; i < 100; i++)
            {
                //
                
                
                //Assert
                Assert.ThrowsException<ArgumentException>(() => simpleBoard[row, column], $"\ni='{i}' \nrow = '{row}' \ncolumn = '{column}'");
                row = rnd.Next(-50, 0);
                column = rnd.Next(-50, 0);
            }
        }


        [TestMethod()]
        public void PrivateGetColumn()
        {
            Random rnd = new Random();
            
            SimpleBoard simpleBoard = new SimpleBoard(8);

            PrivateObject privateObject = new PrivateObject(simpleBoard);
            int[] trueValues = new int[]{
                2, 4, 6, 8 ,
                1, 3, 5, 7,
                2, 4, 6, 8,
                1, 3, 5, 7,
                2, 4, 6, 8 ,
                1, 3, 5, 7,
                2, 4, 6, 8,
                1, 3, 5, 7 };
            for (int i = 1; i <= simpleBoard.Size; i++)
            {
                //
                int k=(int)( privateObject.Invoke("GetColumn",i));
                int trueValue = trueValues[(i - 1)];
                Assert.AreEqual(trueValue, k, $"\ni={i} true={trueValue} value={k}");
                //Assert

            }
            
        }

        [TestMethod()]
        public void PrivateGetRow()
        {
            Random rnd = new Random();

            SimpleBoard simpleBoard = new SimpleBoard(8);

            PrivateObject privateObject = new PrivateObject(simpleBoard);
            int[] trueValues = new int[]{
                1, 1, 1, 1 ,
                2, 2, 2, 2,
                3, 3, 3, 3,
                4, 4, 4, 4,
                5, 5, 5, 5 ,
                6, 6, 6, 6,
                7, 7, 7, 7,
                8, 8, 8, 8 };
            for (int i = 1; i <= simpleBoard.Size; i++)
            {
                //
                int k = (int)(privateObject.Invoke("GetRow", i));
                int trueValue = trueValues[(i - 1)];
                Assert.AreEqual(trueValue, k, $"\ni={i} true={trueValue} value={k}");
                //Assert

            }

        }

        [TestMethod()]
        public void PrivateGetPosition()
        {
            Random rnd = new Random();

            SimpleBoard simpleBoard = new SimpleBoard(8);

            PrivateObject privateObject = new PrivateObject(simpleBoard);
            int trueValue =1;
            for (int r = 1; r <= simpleBoard.Rows; r++)
            {
                for (int c = 1; c <= simpleBoard.Columns; c++)
                {
                    if ((r + c) % 2 == 1)
                    {
                        int k = (int)(privateObject.Invoke("GetPosition", r, c));
                        
                        Assert.AreEqual(trueValue, k, $"\nr={r} c={c} true={trueValue} value={k}");
                        trueValue++;
                    }
                }
            }

        }
    }
}