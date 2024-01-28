using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    class Blackjack : CardGame
    {
        private bool allPlayersOut;
        protected BlackjackPlayer[] players;
        protected BlackjackDealer dealer;
        protected int dealerIndex;
        protected BlackjackPlayer dealerPlayer;

        public Blackjack(int players) : base(players)
        {
            base.deck = new Deck(4);
            allPlayersOut = false;
            this.players = new BlackjackPlayer[players];
            for (int i = 0; i < this.players.Length; i++)
            {
                this.players[i] = new BlackjackPlayer(i);
            }
            this.dealer = new BlackjackDealer(deck, this.players);
            dealerIndex = base.playerCount - 1;
            this.dealerPlayer = this.players[dealerIndex];
        }

        public bool isGameOver()
        {
            throw new NotImplementedException();
        }

        private void verifyAllPlayers()
        {
            short count = 0;
            foreach (Player player in players)
            {
                if (player.getIsOut())
                {
                    count++;
                }
            }
            if (count == playerCount - 1)
            {
                allPlayersOut = true;
            }
        }

        public override void run()
        { bool continueHit = true;
            int result = -1;
            deck.Shuffle();
            Console.WriteLine("Dealing cards to players");
            this.dealer.InitialDeal();
            Console.WriteLine(dealer.ToString());
            foreach (Player player in players)
            {
                Console.WriteLine(player.ToString());
            }
            for (int i = 0; i < 8; i++) {
                dispBuffer();
            }
                for (int i = 0; i < this.players.Length - 1; i++)
                {
                    continueHit = true;
                    players[i].calculateBjHandValue();
                    while (continueHit && players[i].getBlackjackHandValue() <= 21) { 
                    Console.WriteLine(dealer.ToString());
                    Console.WriteLine(this.players[i].ToString());
                    Console.WriteLine("Do you want to hit(0) or stay(1)?");
                    string choice = Console.ReadLine();

                    if (int.TryParse(choice, out result) && result == 0)
                    {
                        dealer.addCardToPlayer(this.players[i]);
                        Console.WriteLine(this.players[i].ToString());
                        players[i].calculateBjHandValue();
                    }
                    else if (int.TryParse(choice, out result) && result == 1)
                    {
                        Console.WriteLine(this.players[i].ToString());
                        continueHit = false;
                    }
                    else
                    {
                        while (result > 1 && result < 0)
                        {
                            Console.WriteLine("Please type 0 to hit, or 1 to stay");
                            choice = Console.ReadLine();
                            if (int.TryParse(choice, out result) && result == 0)
                            {
                                dealer.addCardToPlayer(this.players[i]);
                                Console.WriteLine(this.players[i].ToString());
                                players[i].calculateBjHandValue();
                                }
                            else if (int.TryParse(choice, out result) && result == 1)
                            {
                                Console.WriteLine(this.players[i].ToString());
                                continueHit = false;
                            }
                        }
                    }
                }
                    if (players[i].getBlackjackHandValue() > 21) {
                        Console.WriteLine($"Player {i + 1} busts");
                        players[i].setIsOut();
                        dispBuffer();
                    }
                    else { 
                        Console.WriteLine($"Player {i + 1} is in with {players[i].getBlackjackHandValue()} points");
                        dispBuffer();
                         }
                }
            dealer.updateReveal();
            Console.WriteLine("Dealer revealing cards:");
            Console.WriteLine(dealer);
            dealerPlayer.calculateBjHandValue();
            if (dealerPlayer.getBlackjackHandValue() < 17) {
                Console.WriteLine("Dealer is under 17, drawing another card");
                dealer.addCardToPlayer(dealerPlayer);
                Console.WriteLine(dealer);
            }
            
            
                
            

        }
    }
}
