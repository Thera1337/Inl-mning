using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TjuvOchPolis
{
    class GamePlan
    {
        static int x = 100;
        static int y = 25;
        public static string meet = "";
        static Random random = new Random();
        static string[,] board = new string[y, x];
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
            for (int i = 0; i < 20; i++)
            {
                people.Add(new Medborgare(random.Next(0, y), random.Next(0, x), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            }

            for (int i = 0; i < 20; i++)
            {
                people.Add(new Tjuv(random.Next(0, y), random.Next(0, x), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            }

            for (int i = 0; i < 10; i++)
            {
                people.Add(new Polis(random.Next(0, y), random.Next(0, x), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)));
            }

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
            Console.Write(meet);
            if (meet != String.Empty)
            {
                Thread.Sleep(2500);
            }
        }

        public static void GamePlay()
        {
            foreach (Person person in people)
            {
                person.XPositoin += person.XMovment;
                person.YPosition += person.YMovment;
            }

            GameBoard();
            
            foreach (Person person in people)
            {
                if (person.YPosition == -1 && person.YMovment == -1)
                {
                    person.YPosition = 24;
                }
                else if (person.YPosition == 25 && person.YMovment == 1)
                {
                    person.YPosition = 0;
                }
                if (person.XPositoin == -1 && person.XMovment == -1)
                {
                    person.XPositoin = 99;
                }
                else if (person.XPositoin == 100 && person.XMovment == 1)
                {
                    person.XPositoin = 0;
                }


                if (board[person.YPosition, person.XPositoin] == " ")
                {
                    board[person.YPosition, person.XPositoin] = person.Token;
                }
                else if (board[person.YPosition, person.XPositoin] == "M" && person is Tjuv)
                {
                    board[person.YPosition, person.XPositoin] = "X";
                    meet = "Tjuv stal från medborgare";
                }
                else if (board[person.YPosition, person.XPositoin] == "T" && person is Polis)
                {
                    board[person.YPosition, person.XPositoin] = "X";
                    meet = "Polis beslagtog från tjuv";
                }
            }
        }
    }
}
