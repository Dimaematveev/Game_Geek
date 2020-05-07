using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_GoFish.BL
{
    public class Game
    {
        //Достоинства карт - Cards Ranks
        readonly private string[] cardsRanks;
        //Колода карт - deck Of Cards
        readonly private List<string> deckOfCards;



        //Достоинства карт - Cards Ranks К сожалению все равно можно добавлять.  Unfortunately, you can still add. what to do.
        //TODO: что делать. 
        public string[] CardsRanks { get => cardsRanks; }
        //Колода карт - deck Of Cards. К сожалению все равно можно добавлять.  Unfortunately, you can still add. need to make an array
        //TODO: надо сделать массивом.
        public List<string> DeckOfCards { get => deckOfCards; }
        //Бассейн - pool
        public List<string> Pool;
        //Счет игроков - players Score
        public int[] PlayersScore;
        // Карты игроков - players Cards
        public List<string>[] PlayersCards;
        //Кол-во игроков -  count Player
        public int CountPlayer { get => PlayersCards.Length; }

        public Game()
        {
            cardsRanks = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "D", "K", "A" };
            deckOfCards = new List<string>();
            foreach (var item in CardsRanks)
            {
                for (int i = 0; i < 4; i++)
                {
                    deckOfCards.Add(item);
                }
            }
            Pool = new List<string>();
            Pool.AddRange(DeckOfCards);
            ShuffleADeckOfCards(Pool);
        }
        //ToDo:описать
        /// <summary>
        ///  Добавить кол-во игроков.  автоматически сдлелает 
        ///  Add count player.
        /// </summary>
        /// <param name="countPlayer">Кол-во игроков</param>
        public void AddCountPlayer(int countPlayer)
        {
            
            //Кол-во карт - count Card
            int countCard = 7;
            if (countPlayer >= 5)
            {
                countCard = 5;
            }

            //Счет игроков - players Score
            PlayersScore = new int[countPlayer];

            // Карты игроков - players Cards
            PlayersCards = new List<string>[countPlayer];
            for (int i = 0; i < countPlayer; i++)
            {
                PlayersCards[i] = new List<string>();
                PlayersScore[i] = 0;
            }

            for (int i = 0; i < countCard; i++)
            {
                for (int j = 0; j < countPlayer; j++)
                {
                    PlayersCards[j].Add(Pool[0]);
                    Pool.RemoveAt(0);
                }
            }

        }

        //TODO:Проблема если первый игрок сразу закончит, то все капут??
        /// <summary>
        /// Начать игру!  Begin game
        /// </summary>
        /// <param name="firstPlayer">Кто первый ходит. Who is the first to walk. </param>
        /// <returns>Выводит всех игроков с максимальным счетом. Outer all players with max count.</returns>
        public List<int> BeginGame(int firstPlayer)
        {
            for (int i = firstPlayer; i < CountPlayer; i++)
            {
                OneMove(PlayersScore, PlayersCards, i, Pool);
            }
            while (PlayersScore.Sum() < 13)
            {
                for (int i = 0; i < CountPlayer; i++)
                {
                    OneMove(PlayersScore, PlayersCards, i, Pool);
                }
            }

            return GameOver();
        }

        /// <summary>
        /// Ищет всех игроков с максимальным счетом. 
        /// Find all players with max count
        /// </summary>
        /// <returns>Выводит всех игроков с максимальным счетом. Outer all players with max count.</returns>
        private List<int> GameOver()
        {
            int maxScore = PlayersScore.Max();
            List<int> winPlayer = new List<int>();
            for (int i = 0; i < CountPlayer; i++)
            {
                if (PlayersScore[i]== maxScore)
                {
                    winPlayer.Add(i);
                }
            }

            return winPlayer;
        }

        /// <summary>
        /// Один ход. One move
        /// </summary>
        /// <param name="i">Номер текущего игрока</param>
        private void OneMove(int i)
        {

            throw new NotImplementedException();
        }


        /// <summary>
        /// Перетасовка колоды карт. Входящая колода остается неизменной. 
        /// Shuffling a deck of cards.The incoming deck remains unchanged.
        /// </summary>
        /// <returns>Вывод перетасованной колоды.Shuffled deck output.</returns>
        private void ShuffleADeckOfCards(List<string> deck)
        {
            Random rnd = new Random();
            for (int i = deck.Count; i > 0; i--)
            {
                int ind = rnd.Next(0, i);
                deck.Add(deck[ind]);
                deck.RemoveAt(ind);
            }
        }
        /// <summary>
        /// Проверка на 4 одинаковых карты. Один игрок
        /// Check for 4 identical cards. One player
        /// </summary>
        /// <param name="i">Номер игрока. Number player</param>
        public void CheckFor4EqualCardOnePlayer(int i)
        {
            foreach (var item in PlayersCards[i].GroupBy(x => x).Where(x => x.Count() == 4))
            {
                PlayersScore[i]++;
                PlayersCards[i].RemoveAll(x => x.Equals(item.Key));
            }
        }

        /// <summary>
        /// Проверка на 4 одинаковых карты. все игроки
        /// Check for 4 identical cards. All players
        /// </summary>
        public void CheckFor4EqualCardAllPlayer()
        {
            for (int i = 0; i < CountPlayer; i++)
            {
                CheckFor4EqualCardOnePlayer(i);
            }
            
        }

    }
}
