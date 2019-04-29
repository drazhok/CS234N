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
    public class MexicanTrainTests
    {
        MexicanTrain def;
        MexicanTrain overloaded;
        BoneYard defBoneYard;
        BoneYard overloadedBoneYard;
        Hand defHand;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new MexicanTrain();
            overloaded = new MexicanTrain(1);
            defBoneYard = new BoneYard();
            overloadedBoneYard = new BoneYard(13);
            defHand = new Hand();
        }

        [Test]
        public void TestEngineValue()
        {
            Assert.AreEqual(9, def.EngineValue);
            Assert.AreEqual(1, overloaded.EngineValue);
        }

        [Test]
        public void TestPlayDomino()
        {
            Domino d = new Domino(1, 1);

            defHand.Add(d);

            defHand.Play(overloaded);

            Assert.AreEqual("[1, 1]", overloaded.ToString());
        }

        [Test]
        public void TestPlayWrongDomino()
        {
            Domino d00 = new Domino(0, 0);
            Domino d22 = new Domino(2, 2);

            defHand.Add(d00);
            defHand.Add(d22);

            defHand.Play(def);

            try
            {
                defHand.Play(def);
                Assert.Fail("Should throw an exception that the domino isn't playable.");
            }
            catch
            {
                Assert.Pass("An exception was thrown as expected.");
            }
        }
    }
}
