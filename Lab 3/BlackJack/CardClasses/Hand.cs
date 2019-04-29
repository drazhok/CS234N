using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> hand;
        protected int score;

        /// <summary>
        /// Simply generates an empty hand list.
        /// </summary>
        public Hand() => hand = new List<Card>();

        /// <summary>
        /// Generates a certain number of cards to add.
        /// </summary>
        public Hand(Deck d, int numCards)
        {
            hand = new List<Card>();

            for (int i = 0; i < numCards; i++)
            {
                if (!d.IsEmpty)
                    this.AddCard(d.Deal());

                else
                    throw new ArgumentException("The deck is empty!");
            }
        }

        /// <summary>
        /// Returns the number of cards in the hand.
        /// </summary>
        public int NumCards => hand.Count;

        public void AddCard(Card c) => hand.Add(c);

        public Card GetCard(int index)
        {
            if (index < 0 || index >= hand.Count)
                throw new ArgumentOutOfRangeException("Give a proper index, please.");

            Card c = hand[index];
            hand.RemoveAt(index);

            return c;
        }

        public int IndexOf(Card c) => hand.IndexOf(c);

        public int IndexOf(int value)
        {
            for(int i = 0; i < hand.Count; i++)
                if (hand[i].Value == value) return i;

            return -1;
        }

        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < hand.Count; i++)
                if (hand[i].Value == value && hand[i].Suit == suit) return i;

            return -1;
        }

        public bool HasCard(Card c) => (hand.IndexOf(c) > -1);

        public bool HasCard(int value) => (IndexOf(value) > -1);

        public bool HasCard(int value, int suit) => (IndexOf(value, suit) > -1);

        public Card Discard(int index)
        {
            if (index < 0 || index >= hand.Count)
                throw new ArgumentOutOfRangeException("The index given is invalid!");

            else
            {
                Card c = hand[index];
                hand.RemoveAt(index);

                return c;
            }
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < hand.Count; i++)
                output += hand[i].ToString();

            return output;
        }
    }
}
