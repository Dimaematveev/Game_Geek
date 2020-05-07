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
        //Текущий игрок
        public int CurrentPlayer { get; set; }

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
        public List<int> BeginGame(int firstPlayer, Func<Game, string> fAsksThatCard, Func<Game, int> fIndPlayer)
        {
            for (int i = firstPlayer; i < CountPlayer; i++)
            {
                CurrentPlayer = i;
                OneMove(fAsksThatCard, fIndPlayer);
            }
            while (PlayersScore.Sum() < 13)
            {
                for (int i = 0; i < CountPlayer; i++)
                {
                    CurrentPlayer = i;
                    OneMove(fAsksThatCard, fIndPlayer);
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
        private void OneMove(Func<Game,string> fAsksThatCard, Func<Game, int> fIndPlayer)
        {
            Console.WriteLine($"Ход {CurrentPlayer} Игрока!");
            //ход остаётся у игрока?. is Player Has Move
            bool isPlayerHasMove = false;
            var asksThatCard = fAsksThatCard(this);
            var indPlayer = fIndPlayer(this);
            
            //Если такая карта имеется у другого игрока. If such a card is have to another player.
            if (PlayersCards[indPlayer].Contains(asksThatCard))
            {
                Console.WriteLine($"У игрока {indPlayer} имеется такая карта.");// Player indPlayer have such a card
                //Передача всех карт
                PlayersCards[CurrentPlayer].AddRange(PlayersCards[indPlayer].Where(x => x.Equals(asksThatCard)));
                PlayersCards[indPlayer].RemoveAll(x => x.Equals(asksThatCard));
                isPlayerHasMove = true;
            }
            //Если такой карты не имеется у другого игрока. If such a card is not have to another player.
            else
            {
                Console.WriteLine($"У игрока {indPlayer} нет такой карты."); // Player indPlayer not have such a card
                string pulledCard;
                //Вытаскиваем из бассейна карту, если она равна той что нам надо вытаскиваем еще раз и т.д. 
                //We take out the card from the pool, if it is equal to the one that we need to take out again
                do
                {
                    //Бассейн пуст - pool is Empty
                    if (Pool.Count == 0)
                    {
                        break;
                    }
                    pulledCard = Pool[0];
                    Pool.RemoveAt(0);
                    PlayersCards[CurrentPlayer].Add(pulledCard);
                    Console.WriteLine($"Вы взяли из бассейна {pulledCard} .");//You take from pool ...
                } while (pulledCard == asksThatCard);
            }


            //Если их 4 то счет++ и сброс. if you have 4 equal card then score++ and put cards
            foreach (var item in PlayersCards[CurrentPlayer].GroupBy(x => x).Where(x => x.Count() == 4))
            {
                PlayersScore[CurrentPlayer]++;
                Console.WriteLine($"Вы имеете 4 одинаковых карты {item.Key}. Теперь ваш счет {PlayersScore[CurrentPlayer]}");//if you have 4 equal card ... Now you score
                PlayersCards[CurrentPlayer].RemoveAll(x => x.Equals(item.Key));
            }


            Console.WriteLine($"Имеете Карты :");//Have cards
            Console.Write("\t");
            for (int j = 0; j < PlayersCards[CurrentPlayer].Count; j++)
            {
                Console.Write($"{PlayersCards[CurrentPlayer][j]}, ");
            }
            Console.WriteLine();

            if (isPlayerHasMove)
            {
                OneMove(fAsksThatCard, fIndPlayer);
            }
        }

        /// <summary>
        /// Получить все различные карты игрока. Get all various cards the player
        /// </summary>
        /// <param name="i">Текущий игрок. Current Player</param>
        public string[] GetCardsYouCanAsk()
        {
            return PlayersCards[CurrentPlayer].GroupBy(x => x).Select(x => x.Key).ToArray();
        }
        /// <summary>
        /// Получить индексы игроков у которых можно спросить. Get the index of the players you can ask
        /// </summary>
        /// <param name="i">Номер текущего игрока. number current player</param>
        public int[] GetIndPlayers()
        {
            List<int> insPlayers = new List<int>();
            for (int j = 0; j < CountPlayer; j++)
            {
                if (!CurrentPlayer.Equals(j)) 
                {
                    insPlayers.Add(j);
                }
            }
            return insPlayers.ToArray();
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
