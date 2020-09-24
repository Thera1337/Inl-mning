using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class GamePlan
    {
        static int x = 25;
        static int y = 25;
        static Random random = new Random();
        static string[,] board = new string[x , y];
        public static List<Person> people = new List<Person>();
        public static void GameBoard()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    board[i, j] = " ";
                }
            }
        }
        public static  void People()
        {
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));

            foreach (Person person in people)
            {
                board[person.YPosition, person.XPositoin] = person.Token;
            }
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
