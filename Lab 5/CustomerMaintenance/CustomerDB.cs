using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    class CustomerDB
    {
        public static Customer GetCustomer(int customerID)
        {
            // Creates a connection object.
            SqlConnection connection = MMABooksDB.GetConnection();

            // Our SELECT statement, parameterized.
            string statement = "SELECT * FROM Customers WHERE CustomerID=@customerID;";

            // The command object we're going to modify to access the database.
            SqlCommand command = new SqlCommand(statement, connection);

            // Adds the customerID parameter shown above.
            command.Parameters.AddWithValue("@customerID", customerID);

            try
            {
                // Opens the connection to the SQL server.
                connection.Open();

                // Creates the reader object so we can get the information from the SQL server.
                // Also executes the statement above.
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if(reader.Read())
                {
                    // Creates a new temporary customer object.
                    Customer customer = new Customer();

                    // Sets the variables of our customer object.
                    customer.CustomerID = (int)reader["CustomerID"];
                    customer.Name = (string)reader["Name"];
                    customer.Address = (string)reader["Address"];
                    customer.City = (string)reader["City"];
                    customer.State = (string)reader["State"];
                    customer.ZipCode = (string)reader["ZipCode"];

                    // Returns our customer object.
                    return customer;
                }

                else
                {
                    // No object was found.
                    return null;
                }
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateCustomer(Customer oldCust, Customer newCust)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            // This is a 'verbatim' string literal, which appears to be quite
            // similar to a template string in JavaScript. I like it.
            string statement = @"
                UPDATE Customers SET
                Name = @newName,
                Address = @newAddress,
                City = @newCity,
                State = @newState,
                ZipCode = @newZipCode
                WHERE CustomerID = @oldCustomerID
                AND Name = @oldName
                AND Address = @oldAddress
                AND City = @oldCity
                AND State = @oldState
                AND ZipCode = @oldZipCode;
            ";

            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@newName", newCust.Name);
            command.Parameters.AddWithValue("@newAddress", newCust.Address);
            command.Parameters.AddWithValue("@newCity", newCust.City);
            command.Parameters.AddWithValue("@newState", newCust.State);
            command.Parameters.AddWithValue("@newZipCode", newCust.ZipCode);

            command.Parameters.AddWithValue("@oldCustomerID", oldCust.CustomerID);
            command.Parameters.AddWithValue("@oldName", oldCust.Name);
            command.Parameters.AddWithValue("@oldAddress", oldCust.Address);
            command.Parameters.AddWithValue("@oldCity", oldCust.City);
            command.Parameters.AddWithValue("@oldState", oldCust.State);
            command.Parameters.AddWithValue("@oldZipCode", oldCust.ZipCode);

            try
            {
                connection.Open();

                int rowCount = command.ExecuteNonQuery();

                if (rowCount > 0) return true;
                else return false;
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static int AddCustomer(Customer newCust)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            // SQL query that inserts a new customer with the given parameters. I think
            // it's great that we're learning about parameterized queries first, though
            // I do hope the book teaches WHY we're doing this. I see a lot of SQL injection
            // attacks waiting to happen when browsing GitHub projects. It's a shame.
            string statement = @"
                INSERT INTO Customers (Name, Address, City, State, ZipCode)
                VALUES (@newName, @newAddress, @newCity, @newState, @newZipCode);
            ";

            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@newName", newCust.Name);
            command.Parameters.AddWithValue("@newAddress", newCust.Address);
            command.Parameters.AddWithValue("@newCity", newCust.City);
            command.Parameters.AddWithValue("@newState", newCust.State);
            command.Parameters.AddWithValue("@newZipCode", newCust.ZipCode);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                // Acquires the new customer's ID.
                string getCustomerID = "SELECT IDENT_CURRENT('Customers') FROM Customers;";
                SqlCommand getCustomerIDCommand = new SqlCommand(getCustomerID, connection);
                int CustomerID = Convert.ToInt32(getCustomerIDCommand.ExecuteScalar());

                return CustomerID;
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }

        public static bool DeleteCustomer(Customer toDelete)
        {
            SqlConnection connection = MMABooksDB.GetConnection();

            // Should I be placing the semicolon at the end of each
            // query? I always did it in my node web servers and I
            // still don't know if it truly matters.
            string statement = @"
                DELETE FROM Customers
                WHERE CustomerID = @customerID
                AND   Name = @name
                AND   Address = @address
                AND   City = @city
                AND   State = @state
                AND   ZipCode = @zipCode;
            ";

            SqlCommand command = new SqlCommand(statement, connection);

            command.Parameters.AddWithValue("@customerID", toDelete.CustomerID);
            command.Parameters.AddWithValue("@name", toDelete.Name);
            command.Parameters.AddWithValue("@address", toDelete.Address);
            command.Parameters.AddWithValue("@city", toDelete.City);
            command.Parameters.AddWithValue("@state", toDelete.State);
            command.Parameters.AddWithValue("@zipCode", toDelete.ZipCode);

            try
            {
                connection.Open();

                int count = command.ExecuteNonQuery();

                if (count > 0) return true;
                else return false;
            }

            catch(SqlException ex)
            {
                throw ex;
            }

            finally
            {
                connection.Close();
            }
        }
    }
}
