using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace TjuvOchPolis
{
    class GamePlan
    {
        static int x = 100;
        static int y = 25;
        static int busted;
        static int stolen;
        static string meet = String.Empty;
        static string prisonInfo = String.Empty;
        static Random random = new Random();
        static Person[,] board2 = new Person[y, x];
        static List<Person> people = new List<Person>();
        static List<Sentence> Prison = new List<Sentence>();

        public static void PrisonSentence(Person person)
        {
            Prison.Add(new Sentence(person));
            person.InPrison = true;
            prisonInfo = "Tjuv satt i fängelse.";
        }
        public static void PrisonRelease()
        {
            for (int i = 0; i < Prison.Count; i++)
            {
                if (Prison[i].TimeElapsed() > 30)
                {
                    Prison[i].Inmate.InPrison = false;
                    Prison.RemoveAt(i);
                    i--;
                    prisonInfo = "Tjuv släppt från fängelse.";
                }
            }
        }

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
        public static void People()
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
        }
        public static void PeopleMovement()
        {

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
                    else if (board2[i,j] is Person && !board2[i,j].InPrison)
                    {
                        Console.Write(board2[i, j].Token);
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine(meet);
            Console.WriteLine($"Antal stölder: {stolen}");
            Console.WriteLine($"Antal beslagtagningar: {busted}");
            Console.WriteLine($"Antal tjuvar i fängelset. {Prison.Count}");
            Console.WriteLine(prisonInfo);

            Console.WriteLine("Tid i fängelse:");
            foreach (Sentence tjuv in Prison)
            {
                Console.WriteLine($"Tid avtjänat: {tjuv.TimeElapsed()}");
            }

            if (meet != String.Empty || prisonInfo != String.Empty)
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
            meet = String.Empty;
            prisonInfo = String.Empty;

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

            PrisonRelease();

            foreach (Person person in people)
            {
                Person check = board2[person.YPosition, person.XPositoin];
                if (check is Medborgare && person is Tjuv && !person.InPrison)
                {
                    Person medborgare = check;

                    if (medborgare.Inventory.Count > 0)
                    {
                        int plock = random.Next(0, medborgare.Inventory.Count);
                     
                        person.Inventory.Add(medborgare.Inventory[plock]);
                        medborgare.Inventory.RemoveAt(plock);
                        person.HasCollided = true;
                        medborgare.HasCollided = true;
                    }
                    stolen++;
                    meet = "Tjuv stal från medborgare";
                }
                else if (check is Tjuv && !check.InPrison && person is Polis)
                {
                    Person tjuv = check;

                    if (tjuv.Inventory.Count > 0)
                    {
                        int plock = random.Next(0, tjuv.Inventory.Count);

                        person.Inventory.Add(tjuv.Inventory[plock]);
                        tjuv.Inventory.RemoveAt(plock);
                        person.HasCollided = true;
                        tjuv.HasCollided = true;
                    }
                    busted++;
                    meet = "Polis beslagtog från tjuv";
                    PrisonSentence(tjuv);
                }
            }
        }
    }
}
