using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Blackjack : CardGame
    {
        private bool allPlayersOut;

        public Blackjack(int players) : base(players) {
            base.deck = new Deck(4);
            allPlayersOut = false;
            this.players = new BlackjackPlayer[players];
            for (int i = 0; i < this.players.Length; i++)
            {
                this.players[i] = new BlackjackPlayer(i);
            }
            base.dealer = new BlackjackDealer(deck, base.players);
            base.dealerIndex = base.playerCount - 1;
        }

        public bool isGameOver() {
        throw new NotImplementedException();
        }

        private void verifyAllPlayers() {
            short count = 0;
            foreach (Player player in players) {
                if (player.getIsOut()) {
                    count++;
                }
            }
            if (count == playerCount - 1) { 
            allPlayersOut = true;
            }
        }

        public override void run()
        {
            int result = -1;
            deck.Shuffle();
            Console.WriteLine("Dealing cards to players");
            base.dealer.InitialDeal();
            Console.WriteLine(dealer.ToString());
            foreach (Player player in players) { 
                Console.WriteLine(player.ToString());
            }
            while (!allPlayersOut) {
                for (int i = 0; i < this.players.Length - 1; i++) {
                    Console.WriteLine(dealer.ToString());
                    Console.WriteLine(this.players[i].ToString());
                    Console.WriteLine("Do you want to hit(0) or stay(1)?");
                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out result) && result == 0)
                    {
                        dealer.addCardToPlayer(this.players[i]);
                        Console.WriteLine(this.players[i].ToString());
                    }
                    else if (int.TryParse(choice, out result) && result == 1)
                    {
                        Console.WriteLine(this.players[i].ToString());
                    }
                    else {
                        while (result > 1 && result < 0) {
                            Console.WriteLine("Please type 0 to hit, or 1 to stay");
                            choice = Console.ReadLine();
                            if (int.TryParse(choice, out result) && result == 0)
                            {
                                dealer.addCardToPlayer(this.players[i]);
                                Console.WriteLine(this.players[i].ToString());
                            }
                            else if (int.TryParse(choice, out result) && result == 1)
                            {
                                Console.WriteLine(this.players[i].ToString());
                            }
                        }
                    }
                }
            }

        }
    }
}
