namespace CardGamesCSharp
{
    /**
     * @brief The abstract Dealer class stores the deck for the game, and current card.
     * Function stubs are useful in every card game for distributing cards to players.
     */
    abstract class Dealer
    {
        //The deck for the CardGame which is managed by the Dealer.
        protected Deck deck;
        //The current card on top of this.deck.
        protected int currentCard;

        /**
         * @brief The constructor for the Dealer class initializes the following variables: <br>
         * this.deck is assigned to the passed in deck.
         * this.current card is initialized to the original top card, 0.
         * @param deck The deck used by the Dealer.
         */
        protected Dealer(Deck deck)
        {
            this.deck = deck;
            this.currentCard = 0;
        }

        /**
         * @brief InitialDeal is configured in the respective 
         * Dealer subclass to deal the starting cards to all players (and sometimes the dealer as well).
         */
        abstract public void InitialDeal();

        /**
         * @brief The addCardToPlayer method is configured in a Dealer subclass to give a card to the passed in player.
         */
        abstract public void addCardToPlayer(Player player);
    }
}
