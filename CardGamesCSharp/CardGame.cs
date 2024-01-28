using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    abstract class CardGame
    {
 
        protected Deck deck;
        protected int playerCount;
        protected int turn;

        protected CardGame(int players)
        {
            this.playerCount = players;
            this.turn = 0;
        }
        public static void dispBuffer() {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine();
            }
        }
        abstract public void run();
    }
}
