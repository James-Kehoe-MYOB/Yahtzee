using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee {
    public class ScoreCalculator {
        private const int NUMBER_OF_DICE = 5;
        
        public ScoreCalculator() {
            
        }

        private int[] ConvertScore(string input) {
            if (Parser.RollParse(input)) {
                string[] nums = input.Split(',');
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
            int points = 0;
            int[] myNums = ConvertScore(input);
            
            switch (category) {
                case "chance":
                    points = myNums.Sum();
                    break;
                case "yahtzee":
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
                    break;
                case "ones":
                    points += myNums.Count(i => i == 1);
                    break;
                case "twos":
                    points += myNums.Where(i => i == 2).Sum(i => 2);
                    break;
                case "threes":
                    points += myNums.Where(i => i == 3).Sum(i => 3);
                    break;
                case "fours":
                    points += myNums.Where(i => i == 4).Sum(i => 4);
                    break;
                case "fives":
                    points += myNums.Where(i => i == 5).Sum(i => 5);
                    break;
                case "sixes":
                    points += myNums.Where(i => i == 6).Sum(i => 6);
                    break;
                case "pair":
                    var orderedNums = myNums.OrderByDescending(i => i);
                    foreach (var num in orderedNums) {
                        var pair = orderedNums.Where(m => m == num);
                        if (pair.Count() > 1) {
                            points = 2 * pair.First();
                            break;
                        }
                    }
                    break;
                case "two pairs":
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
                    break;
                case "three of a kind":
                    foreach (var num in myNums) {
                        var threeofakind = myNums.Where(m => m == num);
                        if (threeofakind.Count() >= 3) {
                            points = 3 * threeofakind.First();
                        }

                        break;
                    }
                    break;
                case "four of a kind":
                    foreach (var num in myNums) {
                        var fourofakind = myNums.Where(m => m == num);
                        if (fourofakind.Count() >= 4) {
                            points = 4 * fourofakind.First();
                        }

                        break;
                    }
                    break;
                case "small straight":
                    if (input == "1,2,3,4,5") {
                        points = 15;
                    }
                    else {
                        points = 0;
                    }

                    break;
                case "large straight":
                    if (input == "2,3,4,5,6") {
                        points = 20;
                    }
                    else {
                        points = 0;
                    }

                    break;
                case "full house":
                    if (myNums.Distinct().Count() == 2) {
                        var ordered = myNums.OrderByDescending(i => i);
                        var firstitem = myNums.Where(m => m == myNums.First());
                        if (firstitem.Count() == 3 || firstitem.Count() == 2) {
                            points = myNums.Sum();
                        }
                    }
                    break;
            }

            return points;
        }
        
    }
}