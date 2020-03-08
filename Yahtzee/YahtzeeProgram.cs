using System;
using System.Collections.Generic;

namespace Yahtzee {
    class YahtzeeProgram {
        private static int total = 0;
        static List<Dice> hand = new List<Dice> {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };
        static DiceRoller dr = new DiceRoller(hand);
        //static ScoreCalculator sc = new ScoreCalculator();
        static void Main(string[] args) {
            TestRun();
        }
        
        
        
        //----Sample Test Run---------------

        static void TestRun() {
            while (ScoreCalculator.used_categories.Count < 15) {
                Console.Write("Roll Dice? ");
                Console.ReadKey();
                foreach (var dice in hand) {
                    dice.Roll();
                }
                Console.WriteLine($"{hand[0].rolledValue}, " +
                                  $"{hand[1].rolledValue}, " +
                                  $"{hand[2].rolledValue}, " +
                                  $"{hand[3].rolledValue}, " +
                                  $"{hand[4].rolledValue}");
            
                Console.Write("Input hold/reroll values: ");
                var answer = Console.ReadLine();
                dr.Reroll(answer);
                Console.WriteLine($"{hand[0].rolledValue}, " +
                                  $"{hand[1].rolledValue}, " +
                                  $"{hand[2].rolledValue}, " +
                                  $"{hand[3].rolledValue}, " +
                                  $"{hand[4].rolledValue}");
            
                Console.Write("Input hold/reroll values: ");
                var answer2 = Console.ReadLine();
                dr.Reroll(answer2);
                Console.WriteLine($"{hand[0].rolledValue}, " +
                                  $"{hand[1].rolledValue}, " +
                                  $"{hand[2].rolledValue}, " +
                                  $"{hand[3].rolledValue}, " +
                                  $"{hand[4].rolledValue}");

                Console.WriteLine("What Category would you like to put this result in? ");
                var category = Console.ReadLine();
                string values = $"{hand[0].rolledValue}," +
                                $"{hand[1].rolledValue}," +
                                $"{hand[2].rolledValue}," +
                                $"{hand[3].rolledValue}," +
                                $"{hand[4].rolledValue}";
                var result = ScoreCalculator.Calculate(values, category);
                total += result;
                Console.WriteLine($"\nYour score is: {result}");
            }
            Console.WriteLine($"Your Final Score is {total}!");
        }
    }
}