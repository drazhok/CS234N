using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CardClasses;

namespace CardTests
{
    [TestFixture]
    class HandTests
    {
        private Hand def;
        private Hand overloaded;
        private Deck defDeck;

        [SetUp]
        public void SetUpAllTests()
        {
            def = new Hand();
            defDeck = new Deck();
            overloaded = new Hand(defDeck, 2);
        }

        [Test]
        public void TestOverloadedConstructor()
        {
            Assert.True(overloaded.NumCards == 2);
        }

        [Test]
        public void TestAddCard()
        {
            def.AddCard(defDeck.Deal());

            Assert.True(def.NumCards == 1);
        }

        [Test]
        public void TestGetCard()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => def.GetCard(0));

            def.AddCard(defDeck.Deal());

            Assert.AreEqual("Ace of Hearts", def.GetCard(0).ToString());
        }

        [Test]
        public void TestNumCards()
        {
            Assert.True(def.NumCards == 0);

            def.AddCard(defDeck.Deal());

            Assert.True(def.NumCards == 1);

            def.AddCard(defDeck.Deal());

            Assert.True(def.NumCards == 2);
        }

        [Test]
        public void TestIndexOf()
        {
            Card c = new Card(1, 1);

            def.AddCard(c);

            Assert.True(def.IndexOf(c) == 0);

            Card discarded = def.GetCard(0);

            Assert.True(def.IndexOf(c) == -1);

            def.AddCard(c);

            Assert.True(def.IndexOf(1) == 0);

            discarded = def.GetCard(0);

            Assert.True(def.IndexOf(1) == -1);

            def.AddCard(c);

            Assert.True(def.IndexOf(1, 1) == 0);

            discarded = def.GetCard(0);

            Assert.True(def.IndexOf(1, 1) == -1);
        }

        [Test]
        public void TestHasCard()
        {
            Card c = new Card(1, 1);

            def.AddCard(c);

            Assert.True(def.HasCard(c));
            Assert.True(def.HasCard(1));
            Assert.True(def.HasCard(1, 1));

            Card discarded = def.GetCard(0);

            Assert.False(def.HasCard(c));
            Assert.False(def.HasCard(1));
            Assert.False(def.HasCard(1, 1));
        }

        [Test]
        public void TestToString()
        {
            def.AddCard(defDeck.Deal());

            Assert.AreEqual("Ace of Hearts", def.ToString());
        }
    }
}
