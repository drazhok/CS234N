using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class BJHand : Hand
    {
        public BJHand() : base(){}

        /// <summary>
        /// Automatically draws a certain number of cards.
        /// </summary>
        public BJHand(Deck d, int numCards) : base(d, numCards){}

        /// <summary>
        /// Calculates the score of the hand.
        /// </summary>
        public int Score {
            get
            {
                int score = 0;

                foreach (Card card in hand)
                    score += card.Value;

                return score;
            }
        }

        /// <summary>
        /// Helper method that determines if an ace is contained within
        /// the hand.
        /// </summary>
        public bool HasAce
        {
            get
            {
                foreach (Card card in hand)
                    if (card.IsAce()) return true;

                return false;
            }
        }

        /// <summary>
        /// Determines if the hand is busted or
        /// not.
        /// </summary>
        public bool IsBusted => (Score > 21);
    }
}
