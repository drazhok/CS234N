using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class BoneYard
    {
        private List<Domino> boneyard;

        public delegate void EmptyHandler(BoneYard by);
        public event EmptyHandler Empty;

        public BoneYard() => boneyard = new List<Domino>();

        public BoneYard(int maxDots)
        {
            boneyard = new List<Domino>();

            for (int i = 0; i <= maxDots; i++)
                for (int o = i; o <= maxDots; o++)
                    boneyard.Add(new Domino(i, o));
        }

        public void Shuffle()
        {
            Random RNG = new Random();

            for (int current = 0; current < boneyard.Count; current++)
            {
                int random = RNG.Next(0, boneyard.Count);
                Domino tempDomino = boneyard[current];
                boneyard[current] = boneyard[random];
                boneyard[random] = tempDomino;
            }
        }

        public bool IsEmpty()
        {
            if (boneyard.Count == 0)
            {
                //Empty(this);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int DominosRemaining => boneyard.Count;

        public Domino Draw()
        {
            if (boneyard.Count == 0)
                return null;

            Random RNG = new Random();
            int i = RNG.Next(0, boneyard.Count);
            Domino domino = boneyard[i];
            boneyard.RemoveAt(i);
            return domino;
        }

        public Domino this[int index]
        {
            get => boneyard[index];
            set => boneyard[index] = value;
        }

        public override string ToString()
        {
            string list = "";

            foreach (Domino domino in boneyard)
                list += domino.ToString();

            return list;
        }
    }
}
