using System;
using System.Collections.Generic;
using System.Linq;
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
        //static string[,] board = new string[y, x];
        static Person[,] board2 = new Person[y, x];
        public static List<Person> people = new List<Person>();
        public static void GameBoard()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    board2[i, j] = new Dummy(0,0,0,0);
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
                board2[person.YPosition, person.XPositoin] = person;
            }
        }

        public static void PrintBoard()
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (board2[i,j] is Person && board2[i, j].HasCollided)
                    {
                        Console.Write(board2[i, j].Kollision);
                    }
                    else if (board2[i,j] is Person)
                    {
                        Console.Write(board2[i, j].Token);
                    }
                }
                Console.Write("\n");
            }
            Console.Write(meet);
            if (meet != String.Empty)
            {
                Thread.Sleep(2500);
            }
        }
        public static void PlaceBoard()
        {
            GameBoard();
            foreach (Person person in people)
            {
                board2[person.YPosition, person.XPositoin] = person;
            }
        }

        public static void GamePlay()
        {
            foreach (Person person in people)
            {
                person.XPositoin += person.XMovment;
                person.YPosition += person.YMovment;
            }

            foreach (Person person in people)
            {
                person.HasCollided = false;
            }

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
            }

            foreach (Person person in people)
            {
                if (board2[person.YPosition, person.XPositoin] == null)
                {
                    board2[person.YPosition, person.XPositoin] = person;
                }
                else if (board2[person.YPosition, person.XPositoin] is Medborgare && person is Tjuv)
                {
                    Person medborgare = board2[person.YPosition, person.XPositoin];

                    if (medborgare.Inventory.Count > 0)
                    {
                        int plock = random.Next(0, medborgare.Inventory.Count);
                     
                        person.Inventory.Add(medborgare.Inventory[plock]);
                        medborgare.Inventory.RemoveAt(plock);
                        person.HasCollided = true;
                    }
                    meet = "Tjuv stal från medborgare";
                }
                else if (board2[person.YPosition, person.XPositoin] is Tjuv && person is Polis)
                {
                    Person tjuv = board2[person.YPosition, person.XPositoin];

                    if (tjuv.Inventory.Count > 0)
                    {
                        int plock = random.Next(0, tjuv.Inventory.Count);

                        person.Inventory.Add(tjuv.Inventory[plock]);
                        tjuv.Inventory.RemoveAt(plock);
                        person.HasCollided = true;
                    }
                    meet = "Polis beslagtog från tjuv";
                }
            }
        }
    }
}
