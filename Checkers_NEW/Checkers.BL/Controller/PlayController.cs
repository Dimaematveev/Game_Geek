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
            BoardFilling();

        }
        /// <summary>
        /// Заполнение Доски
        /// </summary>
        private void BoardFilling()
        {
            //Количество строк занятыми фигурами.
            int k = 3;
            for (int i = 1; i <= Board.Rows* k / 2; i++)
            {
                Board[i] = new SimpleCheckersCell(BlackPlayer, Pieces[0]);
                Board[Board.Size-i+1] = new SimpleCheckersCell(WhitePlayer, Pieces[0]);
            }
            

        }
    }
}
