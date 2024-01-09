using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    abstract class CardGame
    {
        private Deck deck;
        private int playerCount;
        private Player[] players;
        private int turn;

        protected CardGame(int players) {
            this.playerCount = players;
            this.deck = new Deck(4);
            this.players = new Player[players];
            for (int i = 0; i < this.players.Length; i++)
            {
                this.players[i] = new Player(i);
            }

            this.turn = 0;
        }
        abstract public void run();
    }
}
