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
        private bool reveal;

        public BlackjackDealer(Deck deck, Player[] players) : base(deck,players){
            dealer = this.players[players.Length - 1];
            dealerHand = dealer.getHand();
            reveal = false;
        }

        public override void addCardToPlayer(Player player)
        {
            player.addCard(deck.GetCard(currentCard));
            currentCard++;
        }

        public override void InitialDeal()
        {
            foreach (Player player in players) {
                player.addCard(this.deck.GetCard(currentCard));
                currentCard++;
            }
            foreach (Player player in players)
            {
                player.addCard(this.deck.GetCard(currentCard));
                currentCard++;
            }
        }

        /*public bool dealerBust() {
            short total = 0;
            foreach (Card card in dealerHand) {
                
            }
        }*/

        public override string ToString()
        {
            string str = "Dealer's Hand: ";
            if (reveal)
            {
                for (int i = 0; i < dealer.getHand().Count; i++)
                {
                    str += dealerHand[i].getRepresentation() + " ";
                }
                str += "\n";
            }
            else {
                    str += dealerHand[0].getRepresentation() + " ";
                str += "\n";
            }
            
            return str;

        }

    }
}
