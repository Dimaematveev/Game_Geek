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

            #region Игроки с первоначальным кол-вом карт, и вывод оставшегося бассейна, Счет каждого игрока.
            //Кол-во игроков
            int countPlayer = 2;
            //Кол-во карт
            int countCard = 7;
            if (countPlayer >= 5)
            {
                countCard = 5;
            }

            //Счет игроков
            int[] playersScore = new int[countPlayer];

            // Карты игроков
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

            #region Первоначальная проверка На 4 одинаковые карты
            for (int i = 0; i < countPlayer; i++)
            {
                var fourCards = playersCards[i].GroupBy(x => x).Where(x => x.Count() == 4).ToList();
                if (fourCards != null && fourCards.Count != 0)
                {
                    foreach (var item in fourCards)
                    {
                        playersCards[i].RemoveAll(x=>x.Equals(item.Key));
                        playersScore[i]++;
                    }
                }
            }
            #endregion

            #region ходы игроков
            for (int i = 0; i < countPlayer; i++)
            {
                Console.WriteLine("Напишите карту которую хотите спросить из:");
                Console.Write("\t");
                //Различные карты с количеством
                var variousCards = playersCards[i].GroupBy(x => x).ToList();
                foreach (var card in variousCards)
                {
                    Console.Write($"{card.Key}, ");
                }
                Console.WriteLine();
                Console.WriteLine();
                //Карту которую спрашивает игрок
                string asksThatCard="";
                while (true)
                {
                    string rdl = Console.ReadLine();
                    if (variousCards.Select(x => x.Key).Contains(rdl)) 
                    {
                        asksThatCard = rdl;
                        break;
                    }
                    Console.WriteLine("Нет такой карты у вас! Введите еще раз!!");
                }
                Console.WriteLine();
                Console.WriteLine("Напишите номер игрока у которого хотите спросить из:");
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
                //Индекс игрока у которого спрашивается карта
                int indPlayer = -1;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out indPlayer)) 
                    {
                        if (indPlayer == i) 
                        {
                            Console.WriteLine("Вы не можете спросить у себя!!! Введите еще раз!!"); 
                            continue;
                        }
                        if (indPlayer < 0 || indPlayer >= countPlayer) 
                        {
                            Console.WriteLine("Нет такого игрока!!! Введите еще раз!!");
                            continue;
                        }

                        break;
                    }
                    Console.WriteLine("Это не число!!! Введите еще раз!!");
                }
                Console.WriteLine();

            }
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
