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
            #region Создал Достоинства карт
            //Достоинства карт
            string[] cardsRanks = new string[13] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "V", "D", "K", "T" };
            Console.WriteLine("Достоинства карт:");
            Console.Write("\t");
            for (int i = 0; i < cardsRanks.Length; i++)
            {
                Console.Write($"{i}-{cardsRanks[i]}; ");
            }
            Console.WriteLine();
            #endregion

            #region Создал Колоду карт, не использовал масти
            //Колода карт
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

            #region Создал Бассейн откуда игроки будут брать карты, это перемешанная колода. 
            //Колода карт
            List<string> pool = ShuffleADeckOfCards(deckOfCards);
            Console.WriteLine("Бассейн:");
            Console.Write("\t");
            for (int i = 0; i < pool.Count; i++)
            {
                Console.Write($"{pool[i]}, ");
            }
            Console.WriteLine();
            #endregion

            #region Игроки с первоначальным кол-вом карт, и вывод оставшегося бассейна
            //Кол-во игроков
            int countPlayer = 2;
            //Кол-во карт
            int countCard = 7;
            if (countPlayer >= 5)
            {
                countCard = 5;
            }

            List<string>[] playersCards = new List<string>[countPlayer];
            for (int i = 0; i < countPlayer; i++)
            {
                playersCards[i] = new List<string>();
            }

            for (int i = 0; i < countCard; i++) 
            {
                for (int j = 0; j < countPlayer; j++) 
                {
                    playersCards[j].Add(pool[0]);
                    pool.RemoveAt(0);
                }
            }

            Console.WriteLine($"Карты у игроков:");
            for (int i = 0; i < countPlayer; i++)
            {
                Console.WriteLine($"\tИгрок {i} Имеет карты:");
                Console.Write("\t");
                for (int j = 0; j < playersCards[i].Count; j++)
                {
                    Console.Write($"{playersCards[i][j]}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Оставшийся Бассейн:");
            Console.Write("\t");
            for (int i = 0; i < pool.Count; i++)
            {
                Console.Write($"{pool[i]}, ");
            }
            Console.WriteLine();
            #endregion



            Console.ReadKey();
        }

        /// <summary>
        /// Перетасовка колоды карт. Входящая колода остается неизменной
        /// </summary>
        /// <param name="deck">Колода</param>
        /// <returns>Вывод перетасованной колоды</returns>
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
