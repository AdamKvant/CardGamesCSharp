using System;

namespace CardGamesCSharp
{
    class Program {
        static void Main(string[] args) {
            Deck test = new Deck(2);
            Console.WriteLine(test);
            test.Shuffle();
            Console.WriteLine();
            Console.WriteLine(test);
        }
    }
}