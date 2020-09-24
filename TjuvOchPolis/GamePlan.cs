using System;
using System.Collections.Generic;
using System.Text;

namespace TjuvOchPolis
{
    class GamePlan
    {
        static Random random = new Random();
        static string[,] board = new string[25 , 25];
        static List<Person> people = new List<Person>();
        public void GameBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    board[i, j] = "";
                }
            }
        }
        public void People()
        {
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "P");
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "P");
            people.Add(new Polis(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "P");
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "T");
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "T");
            people.Add(new Tjuv(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "T");
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "M");
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "M");
            people.Add(new Medborgare(random.Next(0, 25 + 1), random.Next(0, 25 + 1), random.Next(-1, 1 + 1), random.Next(-1, 1 + 1)), "M");

            foreach (Person person in people)
            {
                board[person.XPositoin, person.YPosition] = 
            }
        }
    }
}
