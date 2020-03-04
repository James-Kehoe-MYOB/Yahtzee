using System.Text.RegularExpressions;

namespace Yahtzee {
    public static class Parser {
        public static bool RollParse(string input) {
            var expr = "(([1-6]|-),([1-6]|-),([1-6]|-),([1-6]|-),([1-6]|-))";
            if (Regex.IsMatch(input, expr)) {
                return true;
            }
            return false;
        }
    }
}