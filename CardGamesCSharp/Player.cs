using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CardGamesCSharp
{
    /**
     * @brief The Player class is a base abstract class for further developed subclasses.
     */
    abstract class Player
    {
        //Player id
        protected int id;
        //Player hand of cards.
        protected List<Card> hand;
        //Bool for checking if the player is out of their game or not.
        protected bool isOut;

        /**
         * @brief The Player constructor initializes the following class variables: <br>
         * this.id is assigned to the passed in id. <br>
         * this.hand is assigned to an empty List<Card>. <br>
         * this.isOut is assigned false.
         * @param id An integer representing the Player's id.
         */
        public Player(int id)
        {
            this.id = id;
            hand = new List<Card>();
            isOut = false;
        }

        /**
         * @brief Returns the Player's hand.
         * @return this.hand
         */
        public List<Card> getHand() { return hand; }

        /**
         * @brief Returns the Player's id.
         * @return this.id
         */
        public int getId() { return id; }

        /**
         * @brief Adds the passed in Card to the Player.
         * @param card The Card to be added to the Player.
         */
        public void addCard(Card card) { hand.Add(card); }

        /**
         * @brief Returns the bool representing if the Player is still in the game.
         * @return this.isOut
         */
        public bool getIsOut() { return isOut; }

        /**
         * @brief Sets isOut to true.
         */
        public void setIsOut() { isOut = true; }

        /**
         * @brief Abstract ToString method to be implemented by Player subclasses.
         * @return A string representation of the Player subclass' object.
         */
        public abstract string ToString();

    }
}
