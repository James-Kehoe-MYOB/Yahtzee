using System.Collections.Generic;
using Yahtzee;
using Xunit;

namespace YahtzeeTests {
    public class DiceTests {
        private static List<Dice> hand = new List<Dice> {
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice(),
            new Dice()
        };
        
        DiceRoller diceRoller = new DiceRoller(hand);
        [Fact]
        public void CanRollSingleDice() {
            var dice = new Dice();

            var oldvalue = dice.rolledValue;
            dice.Roll();
            var newvalue = dice.rolledValue;
            while (newvalue == oldvalue) {
                dice.Roll();
                newvalue = dice.rolledValue;
            }
            
            Assert.NotEqual(newvalue, oldvalue);
        }

        [Fact]
        public void CanRollManyDiceAtOnce() {
            string input = "1,3,1,4,5";


            List<int> before_values = new List<int> {
                hand[0].rolledValue,
                hand[1].rolledValue,
                hand[2].rolledValue,
                hand[3].rolledValue,
                hand[4].rolledValue
            };
            
            diceRoller.Reroll(input);
            
            List<int> after_values = new List<int> {
                hand[0].rolledValue,
                hand[1].rolledValue,
                hand[2].rolledValue,
                hand[3].rolledValue,
                hand[4].rolledValue
            };
            
            Assert.NotEqual(before_values, after_values);
        }

        [Fact]
        public void HeldDiceDoNotReroll() {
            string input = "1,1,-,3,-";
            List<Dice> Hand = new List<Dice> {
                new Dice {rolledValue = 1},
                new Dice {rolledValue = 1},
                new Dice {rolledValue = 4},
                new Dice {rolledValue = 3},
                new Dice {rolledValue = 6}
            };
            
            diceRoller.Reroll(input);
            
            Assert.Equal(4, Hand[2].rolledValue);
            Assert.Equal(6, Hand[4].rolledValue);
        }
        
    }
}