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

        public override void addCardToPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public override void InitialDeal()
        {
            throw new NotImplementedException();
        }
    }
}
