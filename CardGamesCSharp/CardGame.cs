using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    abstract class CardGame
    {
        protected Dealer dealer;
        protected Deck deck;
        protected int playerCount;
        protected Player[] players;
        protected int turn;
        protected int dealerIndex;

        protected CardGame(int players)
        {
            this.playerCount = players;
            this.turn = 0;
        }
        abstract public void run();
    }
}
