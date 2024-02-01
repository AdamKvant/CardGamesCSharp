using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The abstract Dealer class stores the deck for the game, and current card.
     * Function stubs are useful in every card game for distributing cards to players.
     */
    abstract class Dealer
    {
        protected Deck deck;
        protected int currentCard;

        protected Dealer(Deck deck)
        {
            this.deck = deck;
            this.currentCard = 0;
        }
        abstract public void InitialDeal();

        abstract public void addCardToPlayer(Player player);
    }
}
