using System;

namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlan.GameBoard();
            GamePlan.People();
            GamePlan.PrintBoard();
            while (true)
            {
                GamePlan.GamePlay();
                GamePlan.PrintBoard();
                //Console.ReadLine();
                Console.Clear();
                GamePlan.meet = String.Empty;
            }
        }
    }
}
