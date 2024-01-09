using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Blackjack : CardGame
    {


        public Blackjack(int players) : base(players) {
            base.deck = new Deck(4);
        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }
}
