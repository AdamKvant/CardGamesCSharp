using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class BlackjackDealer : Dealer
    {
        public BlackjackDealer(Deck deck, Player[] players) : base(deck,players){
            
        }

        protected override void addCard(Player player)
        {
            throw new NotImplementedException();
        }

        protected override void DistributeCards()
        {
            throw new NotImplementedException();
        }
    }
}
