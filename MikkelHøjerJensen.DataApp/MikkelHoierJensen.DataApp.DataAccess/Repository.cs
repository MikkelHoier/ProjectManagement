using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelHoierJensen.DataApp.DataAccess
{
    //Designed to perform SQL queries in the SQL database GenericDB
    public abstract class Repository
    {
        #region Fields
        protected readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GenericDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        #endregion


        #region Methods
        protected DataSet Execute(string query)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        } 
        #endregion
    }
}
