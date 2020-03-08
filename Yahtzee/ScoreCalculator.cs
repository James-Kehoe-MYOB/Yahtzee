using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee {
    public static class ScoreCalculator {
        public static List<Category> used_categories = new List<Category>();

        public static int Calculate(string input, string category) {
            var myCategory = Parser.CategoryParse(category);
            var points = 0;
            if (myCategory.HasValue) {
                
                var inputAsIntArray = ConvertScore(input);
                var calculations = new Calculations(inputAsIntArray);

                if (used_categories.Contains((Category) myCategory)) {
                    Console.WriteLine($"Cannot Reuse Category {myCategory}");
                }
                else {
                    switch (myCategory) {
                    case Category.Chance:
                        points = calculations.Chance();
                        used_categories.Add(Category.Chance);
                        break;
                    case Category.Yahtzee:
                        points = calculations.Yahtzee();
                        used_categories.Add(Category.Yahtzee);
                        break;
                    case Category.Ones:
                        points = calculations.Ones();
                        used_categories.Add(Category.Ones);
                        break;
                    case Category.Twos:
                        points = calculations.Twos();
                        used_categories.Add(Category.Twos);
                        break;
                    case Category.Threes:
                        points = calculations.Threes();
                        used_categories.Add(Category.Threes);
                        break;
                    case Category.Fours:
                        points = calculations.Fours();
                        used_categories.Add(Category.Fours);
                        break;
                    case Category.Fives:
                        points = calculations.Fives();
                        used_categories.Add(Category.Fives);
                        break;
                    case Category.Sixes:
                        points = calculations.Sixes();
                        used_categories.Add(Category.Sixes);
                        break;
                    case Category.Pair:
                        points = calculations.Pair();
                        used_categories.Add(Category.Pair);
                        break;
                    case Category.TwoPairs:
                        points = calculations.TwoPairs();
                        used_categories.Add(Category.TwoPairs);
                        break;
                    case Category.ThreeOfAKind:
                        points = calculations.ThreeOfAKind();
                        used_categories.Add(Category.ThreeOfAKind);
                        break;
                    case Category.FourOfAKind:
                        points = calculations.FourOfAKind();
                        used_categories.Add(Category.FourOfAKind);
                        break;
                    case Category.SmallStraight:
                        points = calculations.SmallStraight();
                        used_categories.Add(Category.SmallStraight);
                        break;
                    case Category.LargeStraight:
                        points = calculations.LargeStraight();
                        used_categories.Add(Category.LargeStraight);
                        break;
                    case Category.FullHouse:
                        points = calculations.FullHouse();
                        used_categories.Add(Category.FullHouse);
                        break;
                    default:
                        Console.WriteLine("Could not match category");
                        break;
                    }
                }
            }
            else {
                Console.WriteLine("not a valid category, try again: ");
                Calculate(input, Console.ReadLine());
            }
            return points;
        }
        
        
        private static int[] ConvertScore(string input) {
            if (Parser.RollParse(input)) {
                var nums = Parser.ToArray(input);
                var numsAsInt = new int[5];
                for (var i = 0; i < numsAsInt.Length; i++) {
                    numsAsInt[i] = int.Parse(nums[i]);
                }

                return numsAsInt;
            }

            Console.WriteLine("Could not Convert Score");
            return null;
        }
    }
}