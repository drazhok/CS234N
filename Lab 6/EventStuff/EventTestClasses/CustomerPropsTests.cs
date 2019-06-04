using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EventPropsClasses;

using NUnit.Framework;

namespace EventTestClasses
{
    [TestFixture]
    public class CustomerPropsTests
    {
        CustomerProps p;

        [SetUp]
        public void SetUpAllTests()
        {
            p = new CustomerProps();

            p.ID = 1;
            p.name = "Guy";
            p.address = "E. 30th & Pine";
            p.city = "Eugene";
            p.state = "OR";
            p.zip = "97432";
            p.ConcurrencyID = 10;
        }

        [Test]
        public void TestClone()
        {
            CustomerProps clone = (CustomerProps)p.Clone();

            Assert.NotNull(clone);

            p.name = "Che";

            Assert.AreNotEqual(p.name, clone.name);
            Assert.AreNotSame(p, clone);
        }

        [Test]
        public void TestGetState()
        {
            string xml = p.GetState();

            Assert.True(xml.Contains(p.name));
            Assert.True(xml.Contains(p.zip));
            Assert.True(xml.Contains(p.state));
        }

        [Test]
        public void TestSetState()
        {
            string xml = p.GetState();

            CustomerProps p2 = new CustomerProps();

            p2.SetState(xml);

            Assert.AreEqual(p.name, p2.name);
            Assert.AreEqual(p.zip, p2.zip);
            Assert.AreEqual(p.state, p2.state);
        }
    }
}
