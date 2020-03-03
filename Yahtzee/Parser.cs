using System.Text.RegularExpressions;

namespace Yahtzee {
    public static class Parser {
        
        private static bool InputParse(string input) {
            var expr = "(([1-6]|-),([1-6]|-),([1-6]|-),([1-6]|-),([1-6]|-))";
            if (Regex.IsMatch(input, expr)) {
                return true;
            }
            return false;
        }
    }
}