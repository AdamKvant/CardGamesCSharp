using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Blackjack : CardGame
    {
        private Deck deck;
        private int playerCount;
        private Player[] players;
        private int turn;


        public Blackjack(int players) {
            this.playerCount = players;
        }
    }
}
