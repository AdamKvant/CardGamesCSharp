using System;
using System.Transactions;

namespace CardGamesCSharp
{
    class Program {
        static void Main(string[] args) {
            CardGame game;
            int gameChoice = -1;
            int players = -1;
            Console.WriteLine("Adam Kvant's Card Games");
            Console.WriteLine("Available games: blackjack(0)");
            Console.Write("Enter the a number to play one of the games above: ");
            string userGame = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter the number of players: ");
            string userPlayers = Console.ReadLine();
            while (gameChoice == -1 || players == -1)
            {
                if (int.TryParse(userGame, out int result)  && (result == 0))
                {
                    gameChoice = result;
                }
                else 
                {
                    Console.WriteLine("Available games: blackjack(0)");
                    Console.Write("Please enter a valid game number: ");
                    userGame = Console.ReadLine();
                    Console.WriteLine();
                    gameChoice = -1;
                }
                if (int.TryParse(userPlayers, out int playernum) && playernum > 0)
                {
                    players = playernum;
                }
                else
                {
                    Console.Write("Please enter a valid number of players greater than 0: ");
                    userPlayers = Console.ReadLine();
                    Console.WriteLine();
                    players = -1;
                }
            }
            switch (gameChoice) {
                case 0:
                    game = new Blackjack(players);
                    game.run();
                    break;
                    
            }





            /* Test Code
            Deck test = new Deck(2);
            Console.WriteLine(test);
            test.Shuffle();
            Console.WriteLine();
            Console.WriteLine(test);

            Player p1 = new Player(1,2);
            Card[] test1 = new Card[2] {new Card('S',1),new Card('D',13)};
            p1.setHand(test1);
            Console.WriteLine();
            Console.WriteLine(p1);*/
        }
    }
}