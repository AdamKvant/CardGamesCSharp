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
            base.dealer = new BlackjackDealer(deck, base.players);
            base.dealerIndex = base.playerCount-1;
            allPlayersOut = false;
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
            deck.Shuffle();
            Console.WriteLine("Dealing cards to players");
            base.dealer.InitialDeal();
            Console.WriteLine(dealer.ToString());
            foreach (Player player in players) { 
                Console.WriteLine(player.ToString());
            }
        }
    }
}
