using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CardGamesCSharp
{
    /**
     * @brief The Deck class makes a 52 * n card deck out of Card objects.
     */
    class Deck
    {
        //Number of Cards in the deck.
        protected int size;
        //The total number of fifty-two card decks in the Deck object.
        protected int deckCount;
        // The array of Card objects that make up the Deck object.
        protected Card[] deck;

        /**
         * @brief The constructor for the Deck class initializes the following variables: <br>
         * this.deckCount is initialized to the passed in deckCount. <br>
         * this.size is assigned to deckCount * 52. <br>
         * this.deck initializes a new Card array of size this.size. <br>
         * this.deck has all cards initialized inside of itself.
         * @param deckCount The number of fifty-two card decks in this.deck.
         */
        public Deck(int deckCount)
        {
            this.deckCount = deckCount;
            this.size = deckCount * 52;
            this.deck = new Card[this.size];
            int value;
            char suit;

            //Initialize all cards inside of the deck
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

                //New Card added to this.deck.
                this.deck[j] = new Card(suit, value);
            }
        }

        /**
         * @brief The Shuffle method uses the Fisher-Yates shuffle algorithm
         * to shuffle this.deck.
         */
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

        /**
         * @brief GetCard returns the Card object at a specifc index.
         * @param index The index of the returned Card.
         * @return this.deck[index]
         */
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

        /**
         * @brief The ToString for a Deck object.
         * Each row in the string is a specific suit.
         * @return The Deck in a string representation.
         */
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
