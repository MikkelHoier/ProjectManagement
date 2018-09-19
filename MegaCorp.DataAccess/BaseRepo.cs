using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorp.DataAccess
{
    public abstract class BaseRepo
    {
        protected readonly string connectionString;

        public BaseRepo(string connectionString)
        {
            if(IsServerConnected(connectionString) == false)
            {
                throw new ArgumentOutOfRangeException(nameof(connectionString),$"{connectionString} is an invalid connection");
            }
            this.connectionString = connectionString;
        }

        protected virtual DataSet Execute(string sqlQuery)
        {
            DataSet resultSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sqlQuery, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }

        private bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
