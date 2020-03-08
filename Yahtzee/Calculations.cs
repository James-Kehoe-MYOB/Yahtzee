using System.Collections.Generic;
using System.Linq;

namespace Yahtzee {
    public class Calculations {
        private const int NumberOfDice = 5;
        private int points;
        private int[] myNums;
        
        public Calculations(int[] myNums) {
            this.myNums = myNums;
        }

        public int Chance() {
            points = myNums.Sum();
            return points;
        }

        public int Yahtzee() {
            var count = 0;
            var targetnum = myNums[0];

            for (int i = 1; i < myNums.Length; i++) {
                if (myNums[i] == targetnum) {
                    count++;
                }
            }

            if (count == NumberOfDice - 1) {
                points = 50;
            }
            else {
                points = 0;
            }
            return points;
        }
        
        public int Ones() {
            points += myNums.Count(i => i == 1);
            return points;
        }
        
        public int Twos() {
            points += myNums.Where(i => i == 2).Sum(i => 2);
            return points;
        }
        
        public int Threes() {
            points += myNums.Where(i => i == 3).Sum(i => 3);
            return points;
        }
        
        public int Fours() {
            points += myNums.Where(i => i == 4).Sum(i => 4);
            return points;
        }
        
        public int Fives() {
            points += myNums.Where(i => i == 5).Sum(i => 5);
            return points;
        }
        
        public int Sixes() {
            points += myNums.Where(i => i == 6).Sum(i => 6);
            return points;
        }
        
        public int Pair() {
            var orderedNums = myNums.OrderByDescending(i => i);
            foreach (var num in orderedNums) {
                var pair = orderedNums.Where(m => m == num);
                if (pair.Count() > 1) {
                    points = 2 * pair.First();
                    break;
                }
            }
            return points;
        }
        
        public int TwoPairs() {
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

            return points;
        }
        
        public int ThreeOfAKind() {
            foreach (var num in myNums) {
                var threeofakind = myNums.Where(m => m == num);
                if (threeofakind.Count() >= 3) {
                    points = 3 * threeofakind.First();
                }

                break;
            }
            return points;
        }
        
        public int FourOfAKind() {
            foreach (var num in myNums) {
                var fourofakind = myNums.Where(m => m == num);
                if (fourofakind.Count() >= 4) {
                    points = 4 * fourofakind.First();
                }
            }
            return points;
        }
        
        public int SmallStraight() {
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
            return points;
        }
        
        public int LargeStraight() {
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
            return points;
        }
        
        public int FullHouse() {
            if (myNums.Distinct().Count() == 2) {
                var ordered = myNums.OrderByDescending(i => i);
                var firstitem = myNums.Where(m => m == myNums.First());
                if (firstitem.Count() == 3 || firstitem.Count() == 2) {
                    points = myNums.Sum();
                }
            }
            return points;
        }
    }
}