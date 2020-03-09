using System;
using System.Collections.Generic;

namespace Yahtzee {
    class YahtzeeProgram {
        private const int NumberOfCategories = 15;
        private static int total = 0;
        static GameHandler gh = new GameHandler();
        static void Main(string[] args) {
            gh.InitGame();
            while (ScoreCalculator.used_categories.Count < NumberOfCategories) {
                gh.MakeTurn();
            }

            total = gh.total;
            Console.WriteLine($"Your Final Score is {total}!");
        }
    }
}