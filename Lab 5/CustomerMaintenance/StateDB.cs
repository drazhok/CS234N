using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    class StateDB
    {
        public static List<State> GetStates()
        {
            // The list we're going to return.
            List<State> states = new List<State>();

            // Creates a new connection to the database.
            SqlConnection connection = MMABooksDB.GetConnection();

            // Selects the StateCode and StateName from the States table.
            string statement = "SELECT * FROM States ORDER BY StateName;";

            SqlCommand command = new SqlCommand(statement, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        State state = new State();

                        state.StateCode = (string) reader["StateCode"];
                        state.StateName = (string) reader["StateName"];

                        states.Add(state);
                    }

                    reader.Close();
                }

                else
                {
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

            return states;
        }
    }
}
