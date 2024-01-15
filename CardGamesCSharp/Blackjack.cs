using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Blackjack : CardGame
    {
        

        public Blackjack(int players) : base(players) {
            base.deck = new Deck(4);
            base.dealer = new BlackjackDealer(deck, base.players);
        }

        public bool isGameOver() {
        throw new NotImplementedException();
        }

        public override void run()
        {
            Console.WriteLine("Dealing cards to players");
            base.dealer.InitialDeal();
            Console.WriteLine($"Dealer's hand:{players[playerCount-1].ToString}");

        }
    }
}
