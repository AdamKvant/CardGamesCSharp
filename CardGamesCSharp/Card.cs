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

        public Card(char suit, int value)
        {
            this.suit = suit;
            this.value = value;
            switch (this.value)
            {
                case 1:
                    this.dispValue = "A";
                    break;
                case int val when val < 11:
                    this.dispValue = value.ToString();
                    break;
                case 11:
                    this.dispValue = "J";
                    break;
                case 12:
                    this.dispValue = "Q";
                    break;
                case 13:
                    this.dispValue = "K";
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

    }
}
