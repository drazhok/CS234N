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

                // reader.Read() will return null if nothing is found, right?
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
    }
}
