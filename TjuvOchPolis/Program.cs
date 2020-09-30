using System;

namespace TjuvOchPolis
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlan.People();
            GamePlan.PlaceBoard();
            while (true)
            {
                GamePlan.GamePlay();
                GamePlan.PlaceBoard();
                GamePlan.PrintBoard();
                Console.SetCursorPosition(0, 0);
            }
        }
    }
}
