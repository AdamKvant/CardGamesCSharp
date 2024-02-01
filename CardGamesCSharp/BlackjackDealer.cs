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
         * base.deck is set to the deck passed in. <br>
         * this.players is initialized to the BlackjackPlayers array passed in. <br>
         * this.dealer is assigned to the last player in the this.players array. <br>
         * this.dealerHand is assigned to the dealer's hand of cards. <br>
         * this.reveal is set to false by default. <br>
         */
        public BlackjackDealer(Deck deck, BlackjackPlayer[] players) : base(deck)
        {
            this.players = players;
            dealer = this.players[players.Length - 1];
            dealerHand = dealer.getHand();
            reveal = false;
        }

        /**
         * @brief The top card on the deck is added to the player passed in.
         * @param player The BlackjackPlayer is having a card added to their hand.
         */
        public override void addCardToPlayer(Player player)
        {
            player.addCard(deck.GetCard(currentCard));
            currentCard++;
        }

        /**
         * @brief Deal two cards to all players in the game (including the dealer).
         */
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

        /**
         * @brief Returns the dealer's hand.
         * @return A List<Card> containing the BlackjackDealer's hand.
         */
        public List<Card> getHand() { return dealerHand; }

        /**
         * @brief Updates the reveal boolean to true
         */
        public void updateReveal()
        {
            reveal = true;
        }

        /**
         * @brief Returns the BlackjackDealer's hand in a string format.
         * If this.reveal is true then show all cards in the dealer's hand.
         * Otherwise, only show one card in the returned string.
         * @return The BlackjackDealer object in string form.
         */
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
