using CardGame_GoFish.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_GoFish.Cons
{
     public class Program2
    {
        static public void Main1()
        {
            Game game = new Game();
            
            #region Создал Достоинства карт. Create Cards Ranks
            Console.WriteLine("Достоинства карт:");
            Console.Write("\t");
            for (int i = 0; i < game.CardsRanks.Length; i++)
            {
                Console.Write($"{i}-{game.CardsRanks[i]}; ");
            }
            Console.WriteLine();
            #endregion
            
            #region Создал Колоду карт, не использовал масти. Create deck of Cards, but not use suits
            Console.WriteLine("Колода:");
            Console.Write("\t");
            for (int i = 0; i < game.DeckOfCards.Count; i++)
            {
                Console.Write($"{game.DeckOfCards[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Создал Бассейн откуда игроки будут брать карты, это перемешанная колода. Create pool, where players take card. Pool is shuffle deck of cards
            //Бассейн - pool
            Console.WriteLine("Бассейн:");
            Console.Write("\t");
            for (int i = 0; i < game.Pool.Count; i++)
            {
                Console.Write($"{game.Pool[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Игроки с первоначальным кол-вом карт, и вывод оставшегося бассейна, Счет каждого игрока. Players with the original number of cards, and withdrawal of the remaining pool.  each player’s score
            //Кол-во игроков -  count Player
            game.AddCountPlayer(2);

            Console.WriteLine($"Карты у игроков:"); //Cards of players
            for (int i = 0; i < game.CountPlayer; i++)
            {
                Console.WriteLine($"\tИгрок {i} Имеет карты:"); //Player i have cards
                Console.Write("\t");
                for (int j = 0; j < game.PlayersCards[i].Count; j++)
                {
                    Console.Write($"{game.PlayersCards[i][j]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Оставшийся Бассейн:"); // out pool
            Console.Write("\t");
            for (int i = 0; i < game.Pool.Count; i++)
            {
                Console.Write($"{game.Pool[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Первоначальная проверка На 4 одинаковые карты. Initial  check for 4 identical card
            game.CheckFor4EqualCardAllPlayer();
            #endregion

            #region ходы игроков. Move player
            while (game.PlayersScore.Sum()<13)
            {
                for (int i = 0; i < game.CountPlayer; i++)
                {
                    game.CurrentPlayer = i;
                    OneMove(game,game.PlayersScore, game.PlayersCards, game.Pool);
                }
            }
            #endregion

            #region Победа. win
            int maxScore = game.PlayersScore.Max();
            var win = game.PlayersScore.Where(x => x.Equals(maxScore));
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
                //TODO: проблема не тот игрок выводится
                Console.WriteLine($"\tИгрок {item} со счетом {maxScore}!"); //Player item with score maxScore
            }
            
            #endregion

            Console.ReadKey();
        }

        /// <summary>
        /// Один ход. One move
        /// </summary>
        /// <param name="game">игра </param>
        private static void OneMove(Game game)
        {
            
            Console.WriteLine($"Ход {game.CurrentPlayer} Игрока!");
            //ход остаётся у игрока?. is Player Has Move
            bool isPlayerHasMove = false;
            string asksThatCard;
            int indPlayer;
            if (game.PlayersCards[game.CurrentPlayer].Count!=0)
            {
                asksThatCard = GetCardAsk(game);
                indPlayer = GetIndPlayer(game);
            }
            else
            {
                Console.WriteLine("Вы не имеете карт, поэтому берете карту из бассейна");//You do not have a card, so take card from the pool
                indPlayer = -1;
                asksThatCard = "-";
            }


            //Если такая карта имеется у другого игрока. If such a card is have to another player.
            if (game.PlayersCards[indPlayer].Contains(asksThatCard))
            {
                Console.WriteLine($"У игрока {indPlayer} имеется такая карта.");// Player indPlayer have such a card
                //Передача всех карт
                game.PlayersCards[game.CurrentPlayer].AddRange(game.PlayersCards[indPlayer].Where(x => x.Equals(asksThatCard)));
                game.PlayersCards[indPlayer].RemoveAll(x=>x.Equals(asksThatCard));
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
                    if (game.Pool.Count==0)
                    {
                        break;
                    }
                    pulledCard = game.Pool[0];
                    game.Pool.RemoveAt(0);
                    game.PlayersCards[game.CurrentPlayer].Add(pulledCard);
                    Console.WriteLine($"Вы взяли из бассейна {pulledCard} .");//You take from pool ...
                } while (pulledCard == asksThatCard);
            }


            //Если их 4 то счет++ и сброс. if you have 4 equal card then score++ and put cards
            foreach (var item in game.PlayersCards[game.CurrentPlayer].GroupBy(x => x).Where(x => x.Count() == 4))
            {
                game.PlayersScore[game.CurrentPlayer]++;
                Console.WriteLine($"Вы имеете 4 одинаковых карты {item.Key}. Теперь ваш счет {game.PlayersScore[game.CurrentPlayer]}");//if you have 4 equal card ... Now you score
                game.PlayersCards[game.CurrentPlayer].RemoveAll(x => x.Equals(item.Key));
            } 
           

            Console.WriteLine($"Имеете Карты :");//Have cards
            Console.Write("\t");
            for (int j = 0; j < game.PlayersCards[game.CurrentPlayer].Count; j++)
            {
                Console.Write($"{game.PlayersCards[game.CurrentPlayer][j]}, ");
            }
            Console.WriteLine();

            if (isPlayerHasMove)
            {
                OneMove(game);
            }

        }

        /// <summary>
        /// Поиск в перечислении
        /// </summary>
        /// <typeparam name="T"> Тип вывода и перечисления </typeparam>
        /// <param name="enumerable"> перечисление в котором будет вестись поиск</param>
        /// <param name="mess1"> сообщение в начале. Какие элементы можно выбрать</param>
        /// <param name="messError"> Сообщение о ошибке</param>
        /// <returns>найденное в перечислении</returns>
        private static T FindToEnumerable<T>(IEnumerable<T> enumerable, string mess1, string messError)
        {
            Console.WriteLine($"{mess1}:");
            Console.Write($"\t");
            foreach (var item in enumerable)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //Индекс игрока у которого спрашивается карта. Index of the player you want to ask the card
            //Карту которую спрашивает игрок.             The card that the player asks
            T IndPlayerCardAsk;
            while (true)
            {
                string rdl = Console.ReadLine().Trim();
                var k = enumerable.Where(x => x.ToString().Equals(rdl));
                if (k.Count() != 0)
                {
                    IndPlayerCardAsk = k.First();
                    break;
                }
                Console.WriteLine($"{messError}");
            }
            Console.WriteLine();
            return IndPlayerCardAsk;
        }


        /// <summary>
        /// Получить индекс игрока у которого будем спрашивать. Get the index of the player we will ask
        /// </summary>
        /// <param name="i">Номер текущего игрока</param>
        private static int GetIndPlayer(Game game)
        {
            string mess = "Напишите номер игрока у которого хотите спросить из:";// Write number of the player you want to ask
            string messError = "Нет такого игрока! Введите еще раз!!";// You have not that player. Repeat  please
            return FindToEnumerable(game.GetIndPlayers(), mess, messError);

        }

        /// <summary>
        /// Получить Карту которую будем спрашивать. Get the card we will ask
        /// </summary>
        /// <param name="i">Номер текущего игрока</param>
        private static string GetCardAsk(Game game)
        {
            string mess = "Напишите карту которую хотите спросить из:";// Write the cards you want to ask
            string messError = "Нет такой карты у вас! Введите еще раз!!";// You have not that card
            return FindToEnumerable(game.GetCardsYouCanAsk(), mess, messError);
        }

        
    }
}
