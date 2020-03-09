using System;
using System.Collections.Generic;

namespace Yahtzee {
    public class GameHandler {
        public int total { get; set; }
        private static List<Dice> hand = new List<Dice>();
        private DiceRoller dr;

        public GameHandler() {
            
        }

        public void InitGame() {
            for (int i = 0; i < 5; i++) {
                hand.Add(new Dice()); 
            }
            dr = new DiceRoller(hand);
        }

        public void MakeTurn() {
            int roll = 1;
            Console.Write("Roll Dice? ");
                Console.ReadKey();
                foreach (var dice in hand) {
                    dice.Roll();
                }

                while (roll < 2) {
                    Console.WriteLine($"{hand[0].rolledValue}, " +
                                      $"{hand[1].rolledValue}, " +
                                      $"{hand[2].rolledValue}, " +
                                      $"{hand[3].rolledValue}, " +
                                      $"{hand[4].rolledValue}");
            
                    Console.Write("Input hold/reroll values: ");
                    var answer = Console.ReadLine();
                    dr.Reroll(answer);
                    roll++;
                }
                
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

    }
}