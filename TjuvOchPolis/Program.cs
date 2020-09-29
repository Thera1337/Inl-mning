using System;

namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlan.People();
            GamePlan.PlaceBoard();
            GamePlan.PrintBoard();
            while (true)
            {
                GamePlan.GamePlay();
                GamePlan.PlaceBoard();
                GamePlan.PrintBoard();
                Console.Clear();
            }
        }
    }
}
