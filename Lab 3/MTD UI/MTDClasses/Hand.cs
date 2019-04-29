using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    /// <summary>
    /// Represents a hand of dominos
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// The list of dominos in the hand
        /// </summary>
        private List<Domino> dominos;

        public delegate void EmptyHandler(Hand hand);
        public event EmptyHandler Empty;

        /// <summary>
        /// Creates an empty hand
        /// </summary>
        public Hand() => dominos = new List<Domino>();

        /// <summary>
        /// Creates a hand of dominos from the boneyard.
        /// The number of dominos is based on the number of players
        /// 2–4 players: 10 dominoes each
        /// 5–6 players: 9 dominoes each
        /// 7–8 players: 7 dominoes each
        /// </summary>
        /// <param name="by"></param>
        /// <param name="numPlayers"></param>
        public Hand(BoneYard by, int numPlayers)
        {
            dominos = new List<Domino>();

            int quantity = 0;

            if (numPlayers >= 2 && numPlayers <= 4)
                quantity = 10;

            else if (numPlayers >= 5 && numPlayers <= 6)
                quantity = 9;

            else if (numPlayers >= 7 && numPlayers <= 8)
                quantity = 7;

            else
                quantity = 5;

            for (int i = 0; i < quantity; i++)
                dominos.Add(by.Draw());
        }

        public void Add(Domino d) => dominos.Add(d);

        public int Count => dominos.Count;

        public bool IsEmpty
        {
            get
            {
                if(dominos.Count == 0)
                {
                    //Empty(this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Sum of the score of each domino in the hand
        /// </summary>
        public int Score
        {
            get
            {
                int score = 0;

                foreach (Domino domino in dominos)
                    score += domino.Score;

                return score;
            }
        }

        /// <summary>
        /// Does the hand contain a domino with value in side 1 or side 2?
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        public bool HasDomino(int value)
        {
            foreach (Domino domino in dominos)
                if (domino.Side1 == value || domino.Side2 == value)
                    return true;

            return false;
        }

        /// <summary>
        ///  DOes the hand contain a double of a certain value?
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        public bool HasDoubleDomino(int value)
        {
            foreach (Domino domino in dominos)
                if (domino.Side1 == value && domino.Side2 == value)
                    return true;

            return false;
        }

        /// <summary>
        /// The index of a domino with a value in the hand
        /// </summary>
        /// <param name="value">The number of dots on one side of the domino that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        public int IndexOfDomino(int value)
        {
            for(int i = 0; i < dominos.Count; i++)
                if (dominos[i].Side1 == value || dominos[i].Side2 == value)
                    return i;

            return -1;
        }

        /// <summary>
        /// The index of the do
        /// </summary>
        /// <param name="value">The number of (double) dots that you're looking for</param>
        /// <returns>-1 if the domino doesn't exist in the hand</returns>
        public int IndexOfDoubleDomino(int value)
        {
            for(int i = 0; i < dominos.Count; i++)
                if (dominos[i].Side1 == value && dominos[i].Side2 == value)
                    return i;

            return -1;
        }

        /// <summary>
        /// The index of the highest double domino in the hand
        /// </summary>
        /// <returns>-1 if there isn't a double in the hand</returns>
        public int IndexOfHighDouble()
        {
            int highest = -1;

            for(int i = 0; i < dominos.Count; i++)
            {
                if(dominos[i].IsDouble() && dominos[i].Side1 > highest)
                {
                    highest = i;
                }
            }

            return highest;
        }

        public Domino this[int index]
        {
            get
            {
                if(index < 0 || index >= dominos.Count)
                    throw new ArgumentOutOfRangeException("Invalid index!");

                return dominos[index];
            }
        }

        public void RemoveAt(int index) => dominos.RemoveAt(index);

        /// <summary>
        /// Finds a domino with a certain number of dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDomino(int value)
        {
            int index = IndexOfDomino(value);

            if (index == -1)
                return null;

            Domino found = dominos[index];
            dominos.RemoveAt(index);

            if (found.Side1 == value)
                return found;

            else
            {
                found.Flip();
                return found;
            }
        }

        /// <summary>
        /// Finds a domino with a certain number of double dots in the hand.
        /// If it can find the domino, it removes it from the hand and returns it.
        /// Otherwise it returns null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Domino GetDoubleDomino(int value)
        {
            int index = IndexOfDoubleDomino(value);

            if (index == -1)
                return null;

            else
            {
                Domino domino = dominos[index];

                dominos.RemoveAt(index);

                return domino;
            }
        }

        /// <summary>
        /// Draws a domino from the boneyard and adds it to the hand
        /// </summary>
        /// <param name="by"></param>
        public void Draw(BoneYard by) => dominos.Add(by.Draw());

        /// <summary>
        /// Plays the domino at the index on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino at the index
        /// is not playable.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="t"></param>
        private void Play(int index, Train t)
        {
            bool mustFlip = false;

            Domino domino = dominos[index];

            if(t.IsPlayable(this, domino, out mustFlip))
            {
                dominos.RemoveAt(index);

                if (mustFlip)
                    domino.Flip();

                t.Play(this, domino);
            }

            else
                throw new ArgumentException("That domino can't be played on this train!");
        }

        /// <summary>
        /// Plays the domino from the hand on the train.
        /// Flips the domino if necessary before playing.
        /// Removes the domino from the hand.
        /// Throws an exception if the domino is not in the hand
        /// or is not playable.
        /// </summary>
        public void Play(Domino d, Train t)
        {
            int index = IndexOfDomino(t.PlayableValue);

            if(index == -1)
                throw new ArgumentException("That domino isn't in the hand!");

            t.Play(this, d);
        }

        /// <summary>
        /// Plays the first playable domino in the hand on the train
        /// Removes the domino from the hand.
        /// Returns the domino.
        /// Throws an exception if no dominos in the hand are playable.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Domino Play(Train t)
        {
            int index = IndexOfDomino(t.PlayableValue);

            if (index == -1)
                throw new Exception("No domino in this hand can be played.");

            else
            {
                Domino domino = dominos[index];

                t.Play(this, domino);

                return domino;
            }
        }

        public override string ToString()
        {
            string list = "";

            foreach (Domino domino in dominos)
                list += domino.ToString();

            return list;
        }
    }
}
