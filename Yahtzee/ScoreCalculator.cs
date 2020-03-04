using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee {
    public class ScoreCalculator {
        private const int NUMBER_OF_DICE = 5;
        public List<Category> used_categories = new List<Category>();

        public ScoreCalculator() {
            
        }

        private int[] ConvertScore(string input) {
            if (Parser.RollParse(input)) {
                string[] nums = Parser.ToArray(input);
                int[] numsAsInt = new int[5];
                for (int i = 0; i < numsAsInt.Length; i++) {
                    numsAsInt[i] = Int32.Parse(nums[i]);
                }

                return numsAsInt;
            }

            Console.WriteLine("Could not Convert Score");
            return null;

        }
        
        public int Calculate(string input, string category) {
            Category? cat = Parser.CategoryParse(category);
            int points = 0;
            if (cat.HasValue) {
                
                int[] myNums = ConvertScore(input);

                if (used_categories.Contains((Category) cat)) {
                    Console.WriteLine($"Cannot Reuse Category {cat}");
                }
                else {
                    switch (cat) {
                    case Category.Chance:
                        points = myNums.Sum();
                        used_categories.Add(Category.Chance);
                        break;
                    case Category.Yahtzee:
                        var count = 0;
                        var targetnum = myNums[0];

                        for (int i = 1; i < myNums.Length; i++) {
                            if (myNums[i] == targetnum) {
                                count++;
                            }
                        }

                        if (count == NUMBER_OF_DICE - 1) {
                            points = 50;
                        }
                        else {
                            points = 0;
                        }
                        used_categories.Add(Category.Yahtzee);
                        break;
                    case Category.Ones:
                        points += myNums.Count(i => i == 1);
                        used_categories.Add(Category.Ones);
                        break;
                    case Category.Twos:
                        points += myNums.Where(i => i == 2).Sum(i => 2);
                        used_categories.Add(Category.Twos);
                        break;
                    case Category.Threes:
                        points += myNums.Where(i => i == 3).Sum(i => 3);
                        used_categories.Add(Category.Threes);
                        break;
                    case Category.Fours:
                        points += myNums.Where(i => i == 4).Sum(i => 4);
                        used_categories.Add(Category.Fours);
                        break;
                    case Category.Fives:
                        points += myNums.Where(i => i == 5).Sum(i => 5);
                        used_categories.Add(Category.Fives);
                        break;
                    case Category.Sixes:
                        points += myNums.Where(i => i == 6).Sum(i => 6);
                        used_categories.Add(Category.Sixes);
                        break;
                    case Category.Pair:
                        var orderedNums = myNums.OrderByDescending(i => i);
                        foreach (var num in orderedNums) {
                            var pair = orderedNums.Where(m => m == num);
                            if (pair.Count() > 1) {
                                points = 2 * pair.First();
                                break;
                            }
                        }
                        used_categories.Add(Category.Pair);
                        break;
                    case Category.TwoPairs:
                        var orderedNums2 = myNums.OrderByDescending(i => i);
                        int pairs = 0;
                        List<int> pair_vals = new List<int>();
                        foreach (var num in orderedNums2) {
                            var pair = orderedNums2.Where(m => m == num);
                            
                            if (pair.Count() > 1 && !pair_vals.Contains(num)) {
                                if (pairs < 2) {
                                    points += 2 * pair.First();
                                    pairs++;
                                    pair_vals.Add(num);
                                }
                            }
                            
                        }
                        used_categories.Add(Category.TwoPairs);
                        break;
                    case Category.ThreeOfAKind:
                        foreach (var num in myNums) {
                            var threeofakind = myNums.Where(m => m == num);
                            if (threeofakind.Count() >= 3) {
                                points = 3 * threeofakind.First();
                            }

                            break;
                        }
                        used_categories.Add(Category.ThreeOfAKind);
                        break;
                    case Category.FourOfAKind:
                        foreach (var num in myNums) {
                            var fourofakind = myNums.Where(m => m == num);
                            if (fourofakind.Count() >= 4) {
                                points = 4 * fourofakind.First();
                            }

                            break;
                        }
                        used_categories.Add(Category.FourOfAKind);
                        break;
                    case Category.SmallStraight:
                        int smallStraightCount = 0;

                        for (int i = 1; i <= 5; i++) {
                            if (myNums.Contains(i)) {
                                smallStraightCount++;
                            }
                        }

                        if (smallStraightCount == 5) {
                            points = 15;
                        }
                        else {
                            points = 0;
                        }
                        used_categories.Add(Category.SmallStraight);
                        break;
                    case Category.LargeStraight:
                        int largeStraightCount = 0;

                        for (int i = 2; i <= 6; i++) {
                            if (myNums.Contains(i)) {
                                largeStraightCount++;
                            }
                        }

                        if (largeStraightCount == 5) {
                            points = 20;
                        }
                        else {
                            points = 0;
                        }
                        used_categories.Add(Category.LargeStraight);
                        break;
                    case Category.FullHouse:
                        if (myNums.Distinct().Count() == 2) {
                            var ordered = myNums.OrderByDescending(i => i);
                            var firstitem = myNums.Where(m => m == myNums.First());
                            if (firstitem.Count() == 3 || firstitem.Count() == 2) {
                                points = myNums.Sum();
                            }
                        }
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
        
    }
}