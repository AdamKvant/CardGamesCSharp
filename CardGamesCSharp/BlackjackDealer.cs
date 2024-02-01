using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief BlackjackDealer is the manager class for all card transfers to players in Blackjack.
     */
    class BlackjackDealer : Dealer

    {
        //The BlackjackPlayer that is the dealer in the game of Blackjack.
        private BlackjackPlayer dealer;
        //The hand tied to the dealer.
        private List<Card> dealerHand;
        //Boolean which determines how many cards are revealed in dealer ToString.
        private bool reveal;
        //All players in the Blackjack game.
        private BlackjackPlayer[] players;

        /**
         * @brief Constructor for the BlackjackDealer class, all class variables initialized: <br>
         */
        public BlackjackDealer(Deck deck, BlackjackPlayer[] players) : base(deck)
        {
            this.players = players;
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
            foreach (Player player in players)
            {
                player.addCard(this.deck.GetCard(currentCard));
                currentCard++;
            }
            foreach (Player player in players)
            {
                player.addCard(this.deck.GetCard(currentCard));
                currentCard++;
            }
        }
        public List<Card> getHand() { return dealerHand; }
        public void updateReveal()
        {
            reveal = true;
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
            else
            {
                str += dealerHand[0].getRepresentation() + " ";
                str += "\n";
            }

            return str;

        }

    }
}
