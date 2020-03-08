using System;
using System.ComponentModel;
using Yahtzee;
using Xunit;

namespace YahtzeeTests {
    public class ScoreTests {
        //ScoreCalculator calculator = new ScoreCalculator();
        [Fact]
        public void ChanceReturnsSumOfDice() {
            //Arrange
            var input = "1,1,3,3,6";

            //Act
            var finalscore = ScoreCalculator.Calculate(input, "chance");

            //Assert
            Assert.Equal(14, finalscore);
            Assert.Contains(Category.Chance, ScoreCalculator.used_categories);
            
        }

        [Fact]
        public void ProperYahtzeeReturnsFifty() {
            //Arrange
            var input = "1,1,1,1,1";
            
            //Act
            var finalscore = ScoreCalculator.Calculate(input, "yahtzee");
            
            //Assert
            Assert.Equal(50, finalscore);
        }
        
        
        [Fact]
        public void ImproperYahtzeeReturnsZero() {
            var input = "1,1,3,1,4";

            var finalscore = ScoreCalculator.Calculate(input, "yahtzee");
            
            Assert.Equal(0, finalscore);
        }
        
        [Fact]
        public void NumberCategoriesReturnTotalOfGivenNumber() {
            var input = "1,1,2,4,4";
            var input2 = "3,5,5,5,6";

            var finalscore1 = ScoreCalculator.Calculate(input, "ones");
            var finalscore2 = ScoreCalculator.Calculate(input, "twos");
            var finalscore3 = ScoreCalculator.Calculate(input2, "threes");
            var finalscore4 = ScoreCalculator.Calculate(input, "fours");
            var finalscore5 = ScoreCalculator.Calculate(input2, "fives");
            var finalscore6 = ScoreCalculator.Calculate(input2, "sixes");
            
            Assert.Equal(2, finalscore1);
            Assert.Equal(2, finalscore2);
            Assert.Equal(3, finalscore3);
            Assert.Equal(8, finalscore4);
            Assert.Equal(15, finalscore5);
            Assert.Equal(6, finalscore6);
            
        }

        [Fact]
        public void PairReturnsSumOfHighestPair() {
            var input = "3,3,3,4,4";

            var finalscore = ScoreCalculator.Calculate(input, "pair");

            Assert.Equal(8, finalscore);
        }
        
        [Fact]
        public void TwoPairsReturnsSumofTwoHighestPairs() {
            var input = "1,1,2,3,3";

            var finalscore = ScoreCalculator.Calculate(input, "two pairs");
            
            Assert.Equal(8, finalscore);
        }

        [Fact]
        public void ThreeOfAKindReturnsSumOfSameNumber() {
            var input = "3,3,3,4,5";

            var finalscore = ScoreCalculator.Calculate(input, "three of a kind");

            Assert.Equal(9, finalscore);
        }

        [Fact]
        public void FourOfAKindReturnsSumOfSameNumber() {
            var input = "2,2,2,2,5";

            var finalscore = ScoreCalculator.Calculate(input, "four of a kind");

            Assert.Equal(8, finalscore);
        }

        [Fact]

        public void SmallStraightReturnsSumOfSequentialDice() {
            var input = "1,2,3,4,5";

            var finalscore = ScoreCalculator.Calculate(input, "small straight");
            
            Assert.Equal(15, finalscore);
        }

        [Fact]
        public void LargeStraightReturnsSumOfSequentialDice() {
            var input = "3,2,5,4,6";

            var finalscore = ScoreCalculator.Calculate(input, "large straight");
            
            Assert.Equal(20, finalscore);
        }

        [Fact]
        public void FullHouseReturnsSumOfTwoOfAKindAndThreeOfAKind() {
            var input1 = "1,1,2,2,2";

            var finalscore1 = ScoreCalculator.Calculate(input1, "full house");

            Assert.Equal(8, finalscore1);
        }
    }
}