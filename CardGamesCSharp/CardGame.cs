using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The abstract class CardGame contains the base functionality
     * needed for all card games that are implemented throughout this project.
     * This class contains a Deck, player count, and turn number.
     */
    abstract class CardGame
    {

        protected Deck deck;
        protected int playerCount;
        protected int turn;

        /**
         * @brief Constructor for Cardgame class, this.playerCount is set to the parameter players.
         * The class variable this.turn is assigned 0. 
         * @param players is an int representing the total number of players.
         * */
        protected CardGame(int players)
        {
            this.playerCount = players;
            this.turn = 0;
        }

        /**
         * @brief The function dispBuffer writes 3 newlines on the screen which allows text in the terminal to be sent off the visible screen.
         */
        public static void dispBuffer(int i)
        {
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine();
            }
        }

        /**
         * @brief The run function is declared in subclasses of CardGame.
         * The main game logic for each game happens in the run function.
         */
        abstract public void run();
    }
}
