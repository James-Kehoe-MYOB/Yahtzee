using System;

namespace Yahtzee {
    class Dice {
        private static readonly Random random = new Random();
        public int rolledValue { get; set; } = random.Next(1, 7);

        public Dice() {
            
        }

        public void Roll() {
            rolledValue = random.Next(1, 7);
        }
        
    }
}