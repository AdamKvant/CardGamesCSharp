using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Card
    {
        private char suit;
        private int value;
        private string dispValue;
        private string representation;
        private int blackjackValue;

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
        public string getSuit()
        {
            return this.suit + "";
        }
        public int getValue()
        {
            return this.value;
        }
        public string getDispValue()
        {
            return this.dispValue;
        }
        public string getRepresentation()
        {
            return this.representation;
        }
        public int getBlackjackValue() { return this.blackjackValue; }
    }
}
