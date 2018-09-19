using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RygOgRejs.DataAccess
{
    public abstract class Repository
    {
       protected readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RygOgRejsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected DataSet Execute(string sqlQuery)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            using(SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataSet resultSet = new DataSet();
                adapter.Fill(resultSet);
                return resultSet;
            }            
        }
    }
}
