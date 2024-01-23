using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGamesCSharp
{
    class Deck
    {
        protected int size;
        protected int deckCount;
        protected Card[] deck;

        public Deck(int deckCount)
        {
            this.deckCount = deckCount;
            this.size = deckCount * 52;
            this.deck = new Card[this.size];
            int value;
            char suit;
            for (int j = 0; j < this.size; j++)
            {
                value = (j % 13) + 1;
                int breakpoint = j % (52);
                if (breakpoint < 13)
                {
                    suit = 'S'; // Spades
                }
                else if (breakpoint >= 13 && breakpoint < 26)
                {
                    suit = 'H'; // Hearts
                }
                else if (breakpoint >= 26 && breakpoint < 39)
                {
                    suit = 'C'; // Clubs
                }
                else
                {
                    suit = 'D'; // Diamonds
                }
                this.deck[j] = new Card(suit, value);
            }
        }
        public void Shuffle()
        {
            //Shuffle uses Fisher-Yates Shuffle Algorithm
            Random random = new Random();
            for (int i = deck.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        public Card GetCard(int index)
        {
            if (index >= 0 && index < size)
            {
                return this.deck[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < this.size; i++)
            {
                str += deck[i].getRepresentation() + " ";
                if (i % 13 == 12)
                {
                    str += "\n";
                }
            }
            return str;
        }
    }
}
