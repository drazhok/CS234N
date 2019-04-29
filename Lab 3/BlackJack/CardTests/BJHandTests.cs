using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CardClasses;

namespace CardTests
{
    [TestFixture]
    class BJHandTests
    {
        private BJHand def;
        private BJHand overloaded;
        private Deck defDeck;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new BJHand();
            defDeck = new Deck();
            overloaded = new BJHand(defDeck, 2);
        }

        [Test]
        public void TestOverloadedConstructor() => Assert.True(overloaded.NumCards == 2);

        [Test]
        public void TestScore() => Assert.True(overloaded.Score == 2);

        [Test]
        public void TestHasAce() => Assert.True(overloaded.HasAce);

        [Test]
        public void TestIsBusted()
        {
            Card c = new Card(13, 4);

            def.AddCard(c);
            def.AddCard(c);

            Assert.True(def.IsBusted);
        }
    }
}
