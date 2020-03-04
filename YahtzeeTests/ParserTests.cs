using Yahtzee;
using Xunit;

namespace YahtzeeTests {
    public class ParserTests {
        [Fact]
        public void CanParseWholeSetOfDice() {
            var input = "1,1,1,1,1";

            var result = Parser.RollParse(input);
            
            Assert.True(result);
        }

        [Fact]
        public void CanParseHeldDice() {
            var input = "2,-,-,-,6";

            var result = Parser.RollParse(input);
            
            Assert.True(result);
        }

        [Fact]
        public void CannotParseInvalidString() {
            var input = "12234";
            var input2 = "A,B,C,1,2";

            var result = Parser.RollParse(input);
            var result2 = Parser.RollParse(input2);
            
            Assert.False(result);
            Assert.False(result2);
        }

        [Fact]
        public void CanParseCategory() {
            var input = "three of a kind";

            var result = Parser.CategoryParse(input);
            
            Assert.Equal(Category.ThreeOfAKind, result);
        }
    }
}