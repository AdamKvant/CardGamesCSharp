using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    
    class BlackjackPlayer : Player 
    {

        private short blackjackHandValue;
        public BlackjackPlayer(int id) : base(id)
        {
            blackjackHandValue = 0;
        }

        public void calculateBjHandValue()
        {
            blackjackHandValue = 0;
            short aceCount = 0;
            foreach (Card card in hand)
            {
                if (card.getDispValue().Equals("A"))
                {
                    aceCount++;
                }
                else
                {
                    blackjackHandValue += (short)card.getBlackjackValue();
                }
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (blackjackHandValue + 10 <= 21)
                {
                    blackjackHandValue += 10;
                }
                else
                {
                    blackjackHandValue += 1;
                }
            }

        }




    }
}
