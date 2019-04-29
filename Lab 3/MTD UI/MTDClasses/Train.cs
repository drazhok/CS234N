using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTDClasses
{
    /// <summary>
    /// Represents a generic Train for MTD
    /// </summary>
    public abstract class Train
    {
        protected List<Domino> dominos;
        protected int engineValue;

        public Train()
        {
            dominos = new List<Domino>();
            engineValue = 0;
        }

        public Train(int engineValue)
        {

            dominos = new List<Domino>();

            EngineValue = engineValue;
        }

        public int Count => dominos.Count;

        /// <summary>
        /// The first domino value that must be played on a train
        /// </summary>
        public int EngineValue
        {
            get => engineValue;
            set => engineValue = value;
        }

        public bool IsEmpty => (dominos.Count == 0);

        public Domino LastDomino => (dominos.Count == 0) ? null : dominos[dominos.Count - 1];

        /// <summary>
        /// Side2 of the last domino in the train.  It's the value of the next domino that can be played.
        /// </summary>
        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                    return engineValue;

                return LastDomino.Side2;
            }
        }

        public void Add(Domino d) => dominos.Add(d);

        public Domino this[int index] => dominos[index];

        /// <summary>
        /// Determines whether a hand can play a specific domino on this train and if the domino must be flipped.
        /// Because the rules for playing are different for Mexican and Player trains, this method is abstract.
        /// </summary>
        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        /// <summary>
        /// A helper method that determines whether a specific domino can be played on this train.
        /// It can be called in the Mexican and Player train class implementations of the abstract method
        /// </summary>
        protected bool IsPlayable(Domino d, out bool mustFlip)
        {
            if (IsEmpty)
            {
                if(engineValue == d.Side1)
                {
                    mustFlip = false;
                    return true;
                }
                else if(engineValue == d.Side2)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }

            else
            {
                if(d.Side1 == PlayableValue)
                {
                    mustFlip = false;
                    return true;
                }
                else if(d.Side2 == PlayableValue)
                {
                    mustFlip = true;
                    return true;
                }
                else
                {
                    mustFlip = false;
                    return false;
                }
            }
        }

        virtual public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;

            if (IsPlayable(d, out mustFlip))
            {
                if (mustFlip)
                    d.Flip();

                dominos.Add(d);
            }

            else
                throw new Exception("That domino isn't playable!");
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
