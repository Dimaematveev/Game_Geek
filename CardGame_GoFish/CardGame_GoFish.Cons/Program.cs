using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_GoFish.Cons
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Создал Достоинства карт. Create Cards Ranks
            //Достоинства карт - Cards Ranks
            string[] cardsRanks = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "D", "K", "T" };
            Console.WriteLine("Достоинства карт:");
            Console.Write("\t");
            for (int i = 0; i < cardsRanks.Length; i++)
            {
                Console.Write($"{i}-{cardsRanks[i]}; ");
            }
            Console.WriteLine();
            #endregion

            #region Создал Колоду карт, не использовал масти. Create deck of Cards, but not use suits
            //Колода карт - deck Of Cards
            List<string> deckOfCards = new List<string>();
            foreach (var item in cardsRanks)
            {
                for (int i = 0; i < 4; i++)
                {
                    deckOfCards.Add(item);
                }
            }
            Console.WriteLine("Колода:");
            Console.Write("\t");
            for (int i = 0; i < deckOfCards.Count; i++)
            {
                Console.Write($"{deckOfCards[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Создал Бассейн откуда игроки будут брать карты, это перемешанная колода. Create pool, where players take card. Pool is shuffle deck of cards
            //Бассейн - pool
            List<string> pool = ShuffleADeckOfCards(deckOfCards);
            Console.WriteLine("Бассейн:");
            Console.Write("\t");
            for (int i = 0; i < pool.Count; i++)
            {
                Console.Write($"{pool[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Игроки с первоначальным кол-вом карт, и вывод оставшегося бассейна, Счет каждого игрока. Players with the original number of cards, and withdrawal of the remaining pool.  each player’s score
            //Кол-во игроков -  count Player
            int countPlayer = 2;
            //Кол-во карт - count Card
            int countCard = 7;
            if (countPlayer >= 5)
            {
                countCard = 5;
            }

            //Счет игроков - players Score
            int[] playersScore = new int[countPlayer];

            // Карты игроков - players Cards
            List<string>[] playersCards = new List<string>[countPlayer];
            for (int i = 0; i < countPlayer; i++)
            {
                playersCards[i] = new List<string>();
                playersScore[i] = 0;
            }

            for (int i = 0; i < countCard; i++) 
            {
                for (int j = 0; j < countPlayer; j++) 
                {
                    playersCards[j].Add(pool[0]);
                    pool.RemoveAt(0);
                }
            }

            Console.WriteLine($"Карты у игроков:"); //Cards of players
            for (int i = 0; i < countPlayer; i++)
            {
                Console.WriteLine($"\tИгрок {i} Имеет карты:"); //Player i have cards
                Console.Write("\t");
                for (int j = 0; j < playersCards[i].Count; j++)
                {
                    Console.Write($"{playersCards[i][j]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Оставшийся Бассейн:"); // out pool
            Console.Write("\t");
            for (int i = 0; i < pool.Count; i++)
            {
                Console.Write($"{pool[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Первоначальная проверка На 4 одинаковые карты. Initial  check for 4 identical card
            for (int i = 0; i < countPlayer; i++)
            {
                foreach (var item in playersCards[i].GroupBy(x => x).Where(x => x.Count() == 4))
                {
                    playersScore[i]++;
                    playersCards[i].RemoveAll(x=>x.Equals(item.Key));
                        
                }
            }
            #endregion

            #region ходы игроков. Move player
            while (playersScore.Sum()<13)
            {
                for (int i = 0; i < countPlayer; i++)
                {
                    OneMove(playersScore, playersCards, i, pool);
                }
            }
            #endregion

            #region Победа. win
            int maxScore = playersScore.Max();
            var win = playersScore.Where(x => x.Equals(maxScore));
            if (win.Count() > 1) 
            {
                Console.WriteLine("Победу разделили:");//Victory shared
            }
            else 
            {
                Console.WriteLine("Выиграл:");//won
            }
            foreach (var item in win)
            {
                Console.WriteLine($"\tИгрок {item} со счетом {maxScore}!"); //Player item with score maxScore
            }
            
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Один ход. One move
        /// </summary>
        /// <param name="playersScore">Счет игроков. </param>
        /// <param name="playersCards"> Карты игроков</param>
        /// <param name="i">Номер текущего игрока</param>
        /// <param name="pool">Бассейн</param>
        private static void OneMove(int[] playersScore, List<string>[] playersCards, int i, List<string> pool)
        {
            Console.WriteLine($"Ход {i} Игрока!");
            //ход остаётся у игрока?. is Player Has Move
            bool isPlayerHasMove = false;
            string asksThatCard;
            int indPlayer;
            if (playersCards[i].Count!=0)
            {
                asksThatCard = GetCardAsk(playersCards[i]);
                indPlayer = GetIndPlayer(playersCards.Length, i);
            }
            else
            {
                Console.WriteLine("Вы не имеете карт, поэтому берете карту из бассейна");//You do not have a card, so take card from the pool
                indPlayer = i;
                asksThatCard = "-";
            }


            //Если такая карта имеется у другого игрока. If such a card is have to another player.
            if (playersCards[indPlayer].Contains(asksThatCard))
            {
                Console.WriteLine($"У игрока {indPlayer} имеется такая карта.");// Player indPlayer have such a card
                //Передача всех карт
                playersCards[i].AddRange(playersCards[indPlayer].Where(x => x.Equals(asksThatCard)));
                playersCards[indPlayer].RemoveAll(x=>x.Equals(asksThatCard));
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
                    if (pool.Count==0)
                    {
                        break;
                    }
                    pulledCard = pool[0];
                    pool.RemoveAt(0);
                    playersCards[i].Add(pulledCard);
                    Console.WriteLine($"Вы взяли из бассейна {pulledCard} .");//You take from pool ...
                } while (pulledCard == asksThatCard);
            }


            //Если их 4 то счет++ и сброс. if you have 4 equal card then score++ and put cards
            foreach (var item in playersCards[i].GroupBy(x => x).Where(x => x.Count() == 4))
            {
                playersScore[i]++;
                Console.WriteLine($"Вы имеете 4 одинаковых карты {item.Key}. Теперь ваш счет {playersScore[i]}");//if you have 4 equal card ... Now you score
                playersCards[i].RemoveAll(x => x.Equals(item.Key));
            } 
           

            Console.WriteLine($"Имеете Карты :");//Have cards
            Console.Write("\t");
            for (int j = 0; j < playersCards[i].Count; j++)
            {
                Console.Write($"{playersCards[i][j]}, ");
            }
            Console.WriteLine();

            if (isPlayerHasMove)
            {
                OneMove(playersScore, playersCards, i, pool);
            }

        }

        /// <summary>
        /// Получить индекс игрока у которого будем спрашивать. Get the index of the player we will ask
        /// </summary>
        /// <param name="countPlayer">Количество игроков</param>
        /// <param name="i">Номер текущего игрока</param>
        private static int GetIndPlayer(int countPlayer, int i)
        {
            Console.WriteLine("Напишите номер игрока у которого хотите спросить из:");// Write number of the player you want to ask 
            Console.Write("\t");
            for (int j = 0; j < countPlayer; j++)
            {
                if (i != j)
                {
                    Console.Write($"{j}, ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            //Индекс игрока у которого спрашивается карта. Index of the player you want to ask the card
            int indPlayer = -1;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out indPlayer))
                {
                    if (indPlayer == i)
                    {
                        Console.WriteLine("Вы не можете спросить у себя!!! Введите еще раз!!");//You can not ask yourself. Repeat  please
                        continue;
                    }
                    if (indPlayer < 0 || indPlayer >= countPlayer)
                    {
                        Console.WriteLine("Нет такого игрока!!! Введите еще раз!!"); //There is no such player. Repeat  please
                        continue;
                    }

                    break;
                }
                Console.WriteLine("Это не число!!! Введите еще раз!!");// This is not a number. Repeat  please
            }
            Console.WriteLine();
            return indPlayer;
        }

        /// <summary>
        /// Получить Карту которую будем спрашивать. Get the card we will ask
        /// </summary>
        /// <param name="playerCards">Карты текущего игрока.  current player Cards</param>
        private static string GetCardAsk(List<string> playerCards)
        {
            Console.WriteLine("Напишите карту которую хотите спросить из:");// Write the cards you want to ask 
            Console.Write("\t");
            //Различные карты -             Various cards
            //TODO:Из групировки можно вытащить кол-во карт, но есть ли смысл?
            var variousCards = playerCards.GroupBy(x => x).Select(x=>x.Key).ToList();
            foreach (var card in variousCards)
            {
                Console.Write($"{card}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //Карту которую спрашивает игрок.             The card that the player asks
            string asksThatCard = "";
            while (true)
            {
                string rdl = Console.ReadLine();
                if (variousCards.Contains(rdl))
                {
                    asksThatCard = rdl;
                    break;
                }
                Console.WriteLine("Нет такой карты у вас! Введите еще раз!!");// You have not that card
            }
            Console.WriteLine();
            return asksThatCard;
        }

        /// <summary>
        /// Перетасовка колоды карт. Входящая колода остается неизменной. 
        /// Shuffling a deck of cards.The incoming deck remains unchanged.
        /// </summary>
        /// <param name="deck">Колода</param>
        /// <returns>Вывод перетасованной колоды.</returns>
        private static List<string> ShuffleADeckOfCards(List<string> deck)
        {
            Random rnd = new Random();
            var newDeck = new List<string>();
            newDeck.AddRange(deck);
            for (int i = deck.Count; i > 0; i--)
            {
                int ind = rnd.Next(0, i);
                newDeck.Add(newDeck[ind]);
                newDeck.RemoveAt(ind);
            }
           return newDeck;
        }
    }
}
