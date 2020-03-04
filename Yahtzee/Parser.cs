using System.ComponentModel;
using System.Linq;
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

        public static Category? CategoryParse(string category) {
            char whitespace = ' ';
            var catNoWhitespace = category.Replace(" ", string.Empty);
            if (Category.TryParse(catNoWhitespace, true, out Category myCat)) {
                return myCat;
            }
            return null;

        }

        public static string[] ToArray(string input) {
            string[] nums = input.Split(',');
            return nums;
        }
    }
}