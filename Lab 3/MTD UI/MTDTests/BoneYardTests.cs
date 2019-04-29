using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MTDClasses;

namespace MTDTests
{
    [TestFixture]
    public class BoneYardTests
    {
        BoneYard def;
        BoneYard overloaded;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new BoneYard();
            overloaded = new BoneYard(13);
        }

        [Test]
        public void TestShuffle()
        {
            Domino domino = overloaded[0];

            overloaded.Shuffle();

            Assert.False(overloaded[0].Equals(domino));
        }

        [Test]
        public void TestIsEmpty()
        {
            Assert.True(def.IsEmpty());
        }

        [Test]
        public void TestDominosRemaining()
        {
            int DominosRemaining = overloaded.DominosRemaining;

            Domino drawDomino = overloaded.Draw();

            Assert.False(overloaded.DominosRemaining == DominosRemaining);
        }

        [Test]
        public void TestToString()
        {
            string list = overloaded.ToString();

            // Should be [0, 0]
            string item = list.Substring(0, 6);

            Assert.True(overloaded[0].ToString() == item);
        }
    }
}
