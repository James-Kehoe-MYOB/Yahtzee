using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Yahtzee {
    public class DiceRoller {
        private List<Dice> _hand { get; set; }
        
        public DiceRoller(List<Dice> hand) {
            _hand = hand;
        }

        public void Reroll(string input) {
            if (Parser.RollParse(input)) {
                string[] entries = Parser.ToArray(input);
                for (int i = 0; i < entries.Length; i++) {
                    if (entries[i] != "-") {
                        _hand[i].Roll();
                    }
                }
            }
            else {
                Console.WriteLine("Cannot Parse Input");
            }
        }

        
        
    }
}