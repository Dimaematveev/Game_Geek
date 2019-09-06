using Checkers.BL.Model;
using Checkers.BL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.BL.Controller
{
    /// <summary>
    /// Контроллер игры.
    /// </summary>
    public class PlayController
    {
        private IPlayer BlackPlayer;
        private IPlayer WhitePlayer;
        private IBoard Board;
        private IPiece[] Pieces;
        private bool BoardIsFilling=false;
        private IPlayer CurrentPlayer;
        public PlayController()
        {
            Board = new SimpleBoard(8);
            BlackPlayer = new SimplePlayer("Black",false);
            WhitePlayer = new SimplePlayer("White",true);

            Pieces = new IPiece[2];
            IEnumerable<IHowMove> manMove = new List<IHowMove>
            {
                new SimpleHowMove(1,-1),
                new SimpleHowMove(1,1)
            };
            Pieces[0] = new SimplePiece("Man", manMove);
            IEnumerable<IHowMove> kingMove = new List<IHowMove>
            {
                new SimpleHowMove(-1,-1),
                new SimpleHowMove(1,-1),
                new SimpleHowMove(-1,1),
                new SimpleHowMove(1,1)
            };
            Pieces[1] = new SimplePiece("King", kingMove);
            BoardClear();
            BoardIsFilling = BoardFilling(3);
            CurrentPlayer = WhitePlayer;
        }
        /// <summary>
        /// Заполнение Доски
        /// </summary>
        /// <param name="numRowBegin">Сколько рядов будет заполнено шашками в начале игры</param>
        private bool BoardFilling(int numRowBegin)
        {
            //Количество строк занятыми фигурами.

            if (numRowBegin < Board.Rows/2)
            {
                for (int rBlack = 1; rBlack <= numRowBegin; rBlack++)
                {
                    int rWhite = Board.Rows - rBlack + 1;
                    for (int c = 1; c <= Board.Columns; c++)
                    {
                        if ((rBlack + c) % 2 == 1)
                        {
                            Board[rBlack, c] = new SimpleCheckersCell(WhitePlayer, Pieces[0]);
                        }
                        if ((rWhite + c) % 2 == 1)
                        {
                            Board[rWhite, c] = new SimpleCheckersCell(BlackPlayer, Pieces[0]);
                        }

                    }
                }
                return true;
            }
            return false;
        }
      
        /// <summary>
        /// Очистка Доски
        /// </summary>
        private void BoardClear()
        {
            for (int i = 1; i <= Board.Size; i++)
            {
                Board[i] = null;
            }


        }

        public void Move(int row,int col,int rowNew,int colNew)
        {
            Board[rowNew, colNew] = Board[row, col];
            Board[row, col] = null;
        }
        public void Move(int position, int positionNew)
        {
            Board[positionNew] = Board[position];
            Board[position] = null;
        }
        public void ChangePlayer()
        {
            if (CurrentPlayer== BlackPlayer)
            {
                CurrentPlayer = WhitePlayer;
            }
            else
            {
                CurrentPlayer = BlackPlayer;
            }
        }
        /// <summary>
        /// Возможные ходы для текущего игрока.
        /// </summary>
        /// <returns>Список возможных ходов. 1 элемент это откуда, остальные куда.</returns>
        public List<List<int>> GetPossibleMoves()
        {
            List<List<int>> res = new List<List<int>>();
            for (int r = 1; r <= Board.Rows ; r++)
            {
                for (int c = 1; c <= Board.Columns; c++)
                {
                    var re = Board.GetMov(r, c, CurrentPlayer);
                    if (re!=null)
                    {
                        res.Add(re);
                    }
                    
                }
            }
            return res;
        }

        /// <summary>
        /// Обязательные ходы  для текущего игрока. Прыжок
        /// </summary>
        /// <returns>Список Обязательных ходов. 1 элемент это откуда, остальные куда.</returns>
        public List<List<int>> GetJump()
        {
            List<List<int>> jump = new List<List<int>>();
            for (int r = 1; r <= Board.Rows; r++)
            {
                for (int c = 1; c <= Board.Columns; c++)
                {
                    var re = Board.GetJump(r, c, CurrentPlayer);
                    if (re != null)
                    {
                        jump.Add(re);
                    }
                }
            }

            return jump;
        }

        /// TODO: Пока не знаю куда деть!!! 

        public int Row { get => Board.Rows; }
        public int Column { get => Board.Columns; }
        //название что стоит в ячейке(Игрок+название фигуры)
        public string CheckersCell(int row, int column)
        {
            var temp = Board[row, column];
            string figure = "";
            if (temp != null)
            {
                figure = temp.Player.Name.Substring(0, 1);
                figure += "_";
                figure += temp.Piece.Name.Substring(0, 1);
            }
            figure += "(";
            figure += Board.GetPosition(row,column);
            figure += ")";
            
            return figure;
        }


    }
}
