using System;

namespace Yahtzee {
    class YahtzeeProgram {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            
            var dice = new Dice();

            for (int i = 0; i < 20; i++) {
                Console.WriteLine(dice.rolledValue);
                dice.Roll();
            }
        }
    }
}