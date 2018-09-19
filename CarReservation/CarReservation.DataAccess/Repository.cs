using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.DataAccess
{
    /// <summary>
    /// An abstract class that can be inherited by other repositories to give them the ability to execute SQL queries to CarReservationDB. 
    /// </summary>
    public abstract class Repository
    {
        /// <summary>
        /// Connection string to CarResverationDB.
        /// </summary>
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarReservationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// Executes an SQL statement to CarResvartionDB that returns a DataSet.
        /// </summary>
        /// <param name="query">The SQL statement to be executed. Note: query must return something from the database</param>
        /// <returns>Returns a Dataset with data from CarResverationDB.</returns>
        protected DataSet Execute(string query)
        {
            DataSet dataSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(dataSet);
            }
            return dataSet;
        }

        /// <summary>
        /// Executes an SQL statement without returning a DataSet.
        /// </summary>
        /// <param name="query">The SQL statement to be executed. Note: Must NOT return something from the database</param>
        protected void ExecuteNonQuery(string query)
        {
            SqlCommand myCommand = new SqlCommand(query, new SqlConnection(connectionString));
            myCommand.Connection.Open();
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
        }
    }
}
