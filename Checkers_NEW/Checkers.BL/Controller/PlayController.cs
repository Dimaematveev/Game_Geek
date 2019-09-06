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
        public PlayController()
        {
            Board = new SimpleBoard(8);
            BlackPlayer = new SimplePlayer("Black");
            WhitePlayer = new SimplePlayer("White");

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
            BoardFilling(3);

        }
        /// <summary>
        /// Заполнение Доски
        /// </summary>
        /// <param name="numRowBegin">Сколько рядов будет заполнено шашками в начале игры</param>
        private void BoardFilling(int numRowBegin)
        {
            //Количество строк занятыми фигурами.
           
            for (int i = 1; i <= Board.Rows* numRowBegin / 2; i++)
            {
                Board[i] = new SimpleCheckersCell(BlackPlayer, Pieces[0]);
                Board[Board.Size-i+1] = new SimpleCheckersCell(WhitePlayer, Pieces[0]);
            }
            

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
    }
}
