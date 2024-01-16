using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Player
    {
        private int id;
        private List<Card> hand;
        private bool isOut;
        private short blackjackHandValue;

        public Player(int id)
        {
            this.id = id;
            hand = new List<Card>();
            isOut = false;
            blackjackHandValue = 0;
        }

        public List<Card> getHand() { return hand; }
        public int getId() { return id; }

        public void addCard(Card card) { hand.Add(card);}

        //public void setHand(List<Card> hand) { this.hand = hand; }

        public bool getIsOut() { return isOut; }

        public void setIsOut() { isOut = true; }

        public void calculateBJHandValue() {
            blackjackHandValue = 0;
            short aceCount = 0;
            foreach (Card card in hand) {
                if (card.getDispValue().Equals("A"))
                {
                    aceCount++;
                }
                else {
                    blackjackHandValue += (short) card.getBlackjackValue();
                }
            }

            for (int i = 0; i < aceCount; i++)
            {
                if (blackjackHandValue + 10 <= 21)
                {
                    blackjackHandValue += 10;
                }
                else {
                    blackjackHandValue += 1;
                }
            }

        }

        public override string ToString()
        {
            string str = $"Player {id}\n";
            str += "Hand: ";
            for (int i = 0; i < this.hand.Count; i++) {
                str += this.hand[i].getRepresentation() + " ";
            }
            str += "\n";
            return str;
        }


    }
}
