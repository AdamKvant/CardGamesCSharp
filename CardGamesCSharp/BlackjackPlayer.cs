using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The BlackjackPlayer class inherits from the player class, and adds some additional Blackjack functionality.
     */
    class BlackjackPlayer : Player
    {
        //The point value of the BlackjackPlayer's hand.
        private short blackjackHandValue;

        /**
         * @brief The BlackjackPlayer's constructor initializes the following variables: <br>
         * base.id is initialized to the integer passed in. <br>
         * this.blackjackHand is initially set to 0.
         * @param id is set to the passed in id.
         */
        public BlackjackPlayer(int id) : base(id)
        {
            blackjackHandValue = 0;
        }

        /**
         * @brief ToString Method is overridden, BlackjackPlayer id and hand is formatted into a string.
         * @return The BlackjackPlayer in a string representation.
         */
        public override string ToString()
        {
            string str = $"Player {id + 1}\n";
            str += "Hand: ";
            for (int i = 0; i < this.hand.Count; i++)
            {
                str += this.hand[i].getRepresentation() + " ";
            }
            str += "\n";
            return str;
        }

        /**
         * @brief Returns the blackjackHandValue for the BlackjackPlayer.
         * @return The blackjackHandValue (short).
         */
        public short getBlackjackHandValue() { return blackjackHandValue; }

        /**
         * Calculates the point value of the BlackjackPlayer's hand.
         * This function accounts for aces being 1 or 11 points.
         */
        public void calculateBjHandValue()
        {
            blackjackHandValue = 0;
            short aceCount = 0;

            //Counts the number of aces in the player's hand. If the current card is not an ace,
            //add its point value to blackjackHandValue.
            foreach (Card card in hand)
            {
                if (card.getDispValue().Equals("A"))
                {
                    aceCount++;
                }
                else
                {
                    blackjackHandValue += (short) card.getBlackjackValue();
                }
            }

            //Add appropriate values for aces to player's score.
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
