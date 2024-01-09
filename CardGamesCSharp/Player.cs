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

        public Player(int id)
        {
            this.id = id;
            hand = new List<Card>();
        }

        public List<Card> getHand() { return hand; }
        public int getId() { return id; }

        public void addCard(Card card) { hand.Add(card);}

        //public void setHand(List<Card> hand) { this.hand = hand; }

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
