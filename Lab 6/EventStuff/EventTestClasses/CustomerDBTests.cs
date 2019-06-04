using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventDBClasses;

using NUnit.Framework;

using EventPropsClasses;

using DBCommand = System.Data.SqlClient.SqlCommand;

namespace EventTestClasses
{
    [TestFixture]
    public class CustomerDBTests
    {
        private string dataSource = "Data Source=DESKTOP-OCKQVIP;Initial Catalog=MMABooksUpdated;Integrated Security=True";
        CustomerSQLDB db;
        CustomerProps p;

        [SetUp]
        public void SetUpAllTests()
        {
            db = new CustomerSQLDB(dataSource);
            p = (CustomerProps)db.Retrieve(1);

            // Resets the database each time.
            DBCommand command = new DBCommand();

            command.CommandText = "usp_testingResetData";
            command.CommandType = CommandType.StoredProcedure;

            db.RunNonQueryProcedure(command);
        }

        [Test]
        public void TestRetrieve()
        {
            Assert.AreEqual(1, p.ID);
            Assert.AreEqual("Molunguri, A", p.name);
        }

        [Test]
        public void TestUpdate()
        {
            p.state = "OR";
            bool ok = db.Update(p);

            p = (CustomerProps)db.Retrieve(1);

            Assert.True(ok);
            Assert.AreEqual("OR", p.state);
        }
    }
}
