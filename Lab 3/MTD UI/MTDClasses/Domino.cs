using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    [Serializable()]
    public class Domino
    {
        private int side1;
        private int side2;

        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        public Domino(int p1, int p2)
        {
            side1 = p1;
            side2 = p2;
        }

        public int Side1
        {
            get => side1;
            set
            {
                if (value < 0 || value > 12)
                    throw new ArgumentOutOfRangeException("The domino side value is invalid.");

                side1 = value;
            }
        }
        public int Side2
        {
            get => side2;
            set
            {
                if (value < 0 || value > 12)
                    throw new ArgumentOutOfRangeException("The domino side value is invalid.");

                side2 = value;
            }
        }

        public void Flip()
        {
            int tempSide = side1;
            side1 = side2;
            side2 = tempSide;
        }

        public int Score => side1 + side2;

        public bool IsDouble() => (side1 == side2);
        public string Filename => String.Format("d{0}{1}.png", side1, side2);

        //public override string ToString() => String.Format("Side 1: {0} Side 2: {1}", Side1, Side2);
        public override string ToString() => String.Format("[{0}, {1}]", Side1, Side2);

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Domino dominoObj = (Domino)obj;

            if (dominoObj.Side1 == this.side1 && dominoObj.Side2 == this.side2)
                return true;
            else
                return false;
        }

        public override int GetHashCode() => ToString().GetHashCode();
    }
}
