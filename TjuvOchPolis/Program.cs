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
            for (int i = 0; i < 10; i++)
            {
                GamePlan.GamePlay();
            }
        }
    }
}
