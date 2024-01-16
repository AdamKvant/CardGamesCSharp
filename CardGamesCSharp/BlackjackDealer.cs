using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class BlackjackDealer : Dealer

    {
        private Player dealer;
        private List<Card> dealerHand;

        public BlackjackDealer(Deck deck, Player[] players) : base(deck,players){
            dealer = this.players[players.Length - 1];
            dealerHand = dealer.getHand();
        }

        public override void addCardToPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public override void InitialDeal()
        {
            foreach (Player player in players) {
                player.addCard(this.deck.GetCard(currentCard));
            }
            foreach (Player player in players)
            {
                player.addCard(this.deck.GetCard(currentCard));
            }
        }

        public bool dealerBust() {
            short total = 0;
            foreach (Card card in dealerHand) {
                
            }
        }

        public override string ToString()
        {
            string str = "Dealer's Hand: ";
            for (int i = 0; i < dealer.getHand().Count; i++)
            {
                str += dealerHand[i].getRepresentation() + " ";
            }
            str += "\n";
            return str;

        }

    }
}
