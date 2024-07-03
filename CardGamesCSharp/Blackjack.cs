using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The Blackjack class inherits from the CardGame class, and it contains the core gameplay implementation for Blackjack.
     */
    class Blackjack : CardGame
    {
        // players contains all of the BlackjackPlayers in the current game.
        protected BlackjackPlayer[] players;
        // dealer contains the BlackjackDealer, which manages all card distribution to all players.
        protected BlackjackDealer dealer;
        // dealerIndex is the last index in the array of players, as this is where the dealer is stored.
        protected int dealerIndex;
        // dealerPlayer is a reference to the dealer's BlackjackPlayer object in the the players array.
        protected BlackjackPlayer dealerPlayer;

        /**
         * @brief The Blackjack constructor initializes all class variables:<br>
         * base.deck is set to a deck of four, standard fifty-two card decks (shuffled at the start of run).<br>
         * base.turn is initialized to 0 (not used in Blackjack).<br>
         * base.playerCount is set to the number of players passed in.<br>
         * this.players is set to the number of players+1 to account for the dealer (done in Main).<br>
         * this.players is also filled with new BlackjackPlayer objects.<br>
         * this.dealer is assigned a new BlackjackDealer which is assigned this.deck, and this.players.<br>
         * this.dealerIndex is assigned to the last index in this.players.<br>
         * this.dealerPlayer is assigned to the BlackjackPlayer object in the this.dealer index in this.players.<br>
         * @param players this.players is an int that represents the total number of players, including the dealer.
         */
        public Blackjack(int players) : base(players)
        {
            base.deck = new Deck(4);
            this.players = new BlackjackPlayer[players];
            for (int i = 0; i < this.players.Length; i++)
            {
                this.players[i] = new BlackjackPlayer(i);
            }
            this.dealer = new BlackjackDealer(deck, this.players);
            dealerIndex = base.playerCount - 1;
            this.dealerPlayer = this.players[dealerIndex];
        }

        /**
         * @brief The run method runs the Blackjack game. 
         */
        public override void run()
        {
            //Bool representing if the game will continue (multiple rounds).
            bool gameContinue = true;
            // this.deck is shuffled.
            deck.Shuffle();
            while (gameContinue)
            {
                //Reset player hands.
                foreach (Player player in players)
                {
                    player.clearHand();
                }

                Random r = new Random();
                Console.WriteLine($"Current num: {dealer.returnCurrentCardNum()}");
                if (dealer.returnCurrentCardNum() >= deck.getDeckCount() * r.NextInt64(1, 50))
                {
                    Console.WriteLine("Dealer is reshuffling deck.");
                    dealer.resetCurrentCardNum();
                    dealer.resetCardCount();
                    deck.Shuffle();
                    
                }

                //Every player can continue to hit on their turn by default.
                bool continueHit = true;

                // Used to parse user input for "hit" or "stay".
                int result = -1;


                // InitialDeal is used to deal starting hands to all players and the dealer.
                Console.WriteLine("Dealing cards to players");
                this.dealer.InitialDeal();

                //Print out dealer's hand.
                Console.WriteLine(dealer.ToString());

                //Print out all players' hands.
                foreach (Player player in players)
                {
                    Console.WriteLine(player.ToString());
                }

                //Clear the terminal to prepare for the first player's turn.
                dispBuffer(100);

                //Loop containing all logic for "hit" or "stay" for each player besides the dealer
                for (int i = 0; i < this.players.Length - 1; i++)
                {
                    //continueHit always set to true for each player before their turn.
                    continueHit = true;

                    //Blackjack value calculated for current player.
                    players[i].calculateBjHandValue();

                    // While loop that runs while a player wants to continue adding to their hand,
                    // and has a hand value at or below 21.
                    while (continueHit && players[i].getBlackjackHandValue() <= 21)
                    {
                        //Dealer and current player's hands are displayed
                        Console.WriteLine(dealer.ToString());
                        Console.WriteLine(this.players[i].ToString());
                        Console.WriteLine("Do you want to hit(0) or stay(1)?");

                        //Player's choice recorded.
                        string choice = Console.ReadLine();

                        //If 0 entered, add a card to the player's hand, print their hand, and calculate their hand value.
                        if (int.TryParse(choice, out result) && result == 0)
                        {
                            dealer.addCardToPlayer(this.players[i]);
                            Console.WriteLine(this.players[i].ToString());
                            players[i].calculateBjHandValue();
                        }

                        //If 1 entered, print out player's hand and set continueHit to false to end the player's turn.
                        else if (int.TryParse(choice, out result) && result == 1)
                        {
                            Console.WriteLine(this.players[i].ToString());
                            continueHit = false;
                        }

                        //Same as above, this is error handling for the user inputs above.
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

                    //If a player's hand value is greater than 21, the player busts and they are out of the game.
                    if (players[i].getBlackjackHandValue() > 21)
                    {
                        Console.WriteLine($"Player {i + 1} busts");
                        players[i].setIsOut();
                        dispBuffer(20);
                    }

                    //Otherwise, the player is notified that they are still in.
                    else
                    {
                        Console.WriteLine($"Player {i + 1} is in with {players[i].getBlackjackHandValue()} points");
                        dispBuffer(20);
                    }
                }

                //Update the revealed status for the dealer to be able to see their full hand.
                dealer.updateReveal();
                Console.WriteLine("Dealer revealing cards:");
                dealer.alterCount(dealer.getHand()[1].getValue());
                Console.WriteLine(dealer);
                dealerPlayer.calculateBjHandValue();

                //Adds cards to the dealer's hand until they have a hand value of at least 17.
                while (dealerPlayer.getBlackjackHandValue() < 17)
                {
                    Console.WriteLine("Dealer is under 17, drawing another card");
                    dealer.addCardToPlayer(dealerPlayer);
                    Console.WriteLine(dealer);
                    dealerPlayer.calculateBjHandValue();
                }

                short dealerHandVal = dealerPlayer.getBlackjackHandValue();

                //If the dealer busts, notify all players of their end-of-game status.
                if (dealerHandVal > 21)
                {
                    Console.WriteLine("Dealer busts!");
                    dispBuffer(1);
                    for (int i = 0; i < players.Length - 1; i++)
                    {
                        players[i].calculateBjHandValue();
                        if (players[i].getIsOut())
                        {
                            Console.WriteLine($"Player {players[i].getId()} is still out :(");
                        }
                        else
                        {
                            Console.WriteLine($"Player {players[i].getId()} wins!");
                        }
                    }
                }

                //Otherwise, the dealer is still in, notify all players of their end-of-game status.
                else
                {
                    for (int i = 0; i < players.Length - 1; i++)
                    {
                        players[i].calculateBjHandValue();
                        if (!players[i].getIsOut() && players[i].getBlackjackHandValue() > dealerHandVal)
                        {
                            Console.WriteLine($"Player {players[i].getId()} wins!");
                        }
                        else if (!players[i].getIsOut() && players[i].getBlackjackHandValue() == dealerHandVal)
                        {
                            Console.WriteLine($"Player {players[i].getId()} tied the dealer!");
                        }
                        else if (!players[i].getIsOut() && players[i].getBlackjackHandValue() < dealerHandVal)
                        {
                            Console.WriteLine($"Player {players[i].getId()} loses :(");
                        }
                        else
                        {
                            Console.WriteLine($"Player {players[i].getId()} is still out :(");
                        }

                    }
                }
                Console.WriteLine("Do you want to start a new round(0) or quit(1)?");

                //Player's choice recorded.
                string choice2 = Console.ReadLine();

                //If 0 entered, add a card to the player's hand, print their hand, and calculate their hand value.
                if (int.TryParse(choice2, out result) && result == 0)
                {
                    Console.WriteLine("Starting new round!");
                    dispBuffer(1);
                }

                //If 1 entered, print out player's hand and set continueHit to false to end the player's turn.
                else if (int.TryParse(choice2, out result) && result == 1)
                {
                    Console.WriteLine("Exiting");
                    gameContinue = false;
                }

                //Same as above, this is error handling for the user inputs above.
                else
                {
                    while (result > 1 && result < 0)
                    {
                        Console.WriteLine("Please type 0 to play a new round, or 1 to exit");
                        choice2 = Console.ReadLine();
                        if (int.TryParse(choice2, out result) && result == 0)
                        {
                            Console.WriteLine("Starting new round!");
                            dispBuffer(1);
                        }
                        else if (int.TryParse(choice2, out result) && result == 1)
                        {
                            Console.WriteLine("Exiting");
                            gameContinue = false;
                        }
                    }
                }
            }
        }
    }
}
