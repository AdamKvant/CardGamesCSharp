using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The Card class is used to represent individual cards.
     * This is currently configured to only use the standard fifty-two card deck.
     */
    class Card
    {
        //Suit of the card.
        private char suit;
        //Value of the card (1-13).
        private int value;
        //Display value of the card (A-10,J,Q,K).
        private string dispValue;
        //The display representation of the card (AH, KC,...).
        private string representation;
        //The blackjack value of the card. Aces use extra calculation in BlackjackPlayer.
        private int blackjackValue;

        /**
         * @brief The Card class constructor initializes the following variables: <br>
         * this.suit is assigned the passed in suit. <br>
         * this.value is assigned the passed in value. <br>
         * this.dispValue and this.blackjackValue are assigned based on this.value. <br>
         * this.representation is assigned this.dispValue + this.suit.
         */
        public Card(char suit, int value)
        {
            this.suit = suit;
            this.value = value;
            switch (this.value)
            {
                case 1:
                    this.dispValue = "A";
                    blackjackValue = 1;
                    break;
                case int val when val < 11:
                    this.dispValue = value.ToString();
                    blackjackValue = val;
                    break;
                case 11:
                    this.dispValue = "J";
                    blackjackValue = 10;
                    break;
                case 12:
                    this.dispValue = "Q";
                    blackjackValue = 10;
                    break;
                case 13:
                    this.dispValue = "K";
                    blackjackValue = 10;
                    break;
            }
            this.representation = this.dispValue + this.suit;
        }

        /**
         * @brief returns this.suit as a string.
         * @return this.suit as a string.
         */
        public string getSuit()
        {
            return this.suit + "";
        }

        /**
         * @brief Returns this.value as an int.
         * @return this.value
         */
        public int getValue()
        {
            return this.value;
        }

        /**
         * @brief Returns the dispValue as a string.
         * @return this.dispValue
         */
        public string getDispValue()
        {
            return this.dispValue;
        }

        /**
         * @brief Returns this.representation.
         * @return this.representation
         */
        public string getRepresentation()
        {
            return this.representation;
        }

        /**
         * @brief Returns this.blackjackValue as an int.
         * @return this.blackjackValue
         */
        public int getBlackjackValue()
        {
            return this.blackjackValue;
        }
    }
}
