using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    abstract class Dealer
    {
        protected Deck deck;
        protected Player[] players;
        protected int currentCard;

        protected Dealer(Deck deck, Player[] players) { 
            this.deck = deck;
            this.players = players;
            this.currentCard = 0;
        }
        abstract public void InitialDeal();

        abstract public void addCardToPlayer(Player player);
    }
}
