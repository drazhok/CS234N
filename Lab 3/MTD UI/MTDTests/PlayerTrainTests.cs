using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MTDClasses;
using NUnit.Framework;

namespace MTDTests
{
    [TestFixture]
    public class PlayerTrainTests
    {
        PlayerTrain def;
        BoneYard defBoneYard;
        BoneYard overloadedBoneYard;
        Hand defHand;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new PlayerTrain();
            defBoneYard = new BoneYard();
            overloadedBoneYard = new BoneYard(13);
            defHand = new Hand();
        }

        [Test]
        public void TestPlayDomino()
        {
            defHand.Add(new Domino(0, 0));

            def.Open();

            try
            {
                defHand.Play(def);
            }
            catch
            {
                Assert.Fail("An exception was thrown for some reason.");
            }

            Assert.Pass("There was no exception thrown, as expected.");
        }

        [Test]
        public void TestPlayOnClosedTrain()
        {
            defHand.Add(new Domino(0, 0));

            try
            {
                defHand.Play(def);
                Assert.Fail("Playing on a closed train should have thrown an exception.");
            }
            catch(ArgumentException e)
            {
                Assert.Pass(e.Message);
            }
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.True(def.IsEmpty);

            defHand.Add(new Domino(0, 0));

            def.Open();

            defHand.Play(def);

            Assert.False(def.IsEmpty);
        }

        [Test]
        public void TestOpening()
        {
            defHand.Add(new Domino(0, 0));
            defHand.Add(new Domino(0, 2));

            def.Open();

            try
            {
                defHand.Play(def);
                defHand.Play(def);
            }
            catch
            {
                Assert.Fail("An exception was thrown for some reason.");
            }

            Assert.Pass("An exception wasn't thrown as expected.");
        }

        [Test]
        public void TestIndexer()
        {
            defHand.Add(new Domino(0, 0));
            defHand.Add(new Domino(0, 2));
            defHand.Add(new Domino(2, 4));

            def.Open();

            defHand.Play(def);
            defHand.Play(def);
            defHand.Play(def);

            Assert.AreEqual("[2, 4]", def[0].ToString());
        }
    }
}
