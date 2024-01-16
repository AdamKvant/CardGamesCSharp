using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class BlackjackDealer : Dealer
    {
        public BlackjackDealer(Deck deck, Player[] players) : base(deck,players){
            
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

        public override string ToString()
        {
            Player dealer = this.players[players.Length - 1];
            string str = "Dealer's Hand: ";
            List<Card> dealerHand = dealer.getHand();
            for (int i = 0; i < dealer.getHand().Count; i++)
            {
                str += dealerHand[i].getRepresentation() + " ";
            }
            str += "\n";
            return str;

        }

    }
}
