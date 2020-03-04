using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Yahtzee {
    public class DiceRoller {
        private List<Dice> Hand { get; set; }
        
        public DiceRoller() {
            
        }

        public void Reroll(List<Dice> hand, string input) {
            string[] entries = Parser.ToArray(input);
            for (int i = 0; i < entries.Length; i++) {
                if (entries[i] != "-") {
                    hand[i].Roll();
                }
            }
        }

        
        
    }
}