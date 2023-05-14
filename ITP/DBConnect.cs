using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace IPTAPI
{
    public class DBConnect
    {
        string conString = "Data Source=.;Initial Catalog=IPTDB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command = null;

        public void OpenConnection()
        {
            connection = new SqlConnection(conString);
            connection.Open();

        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public SqlConnection ReturnSqlObj()
        {
            return connection;
        }
    }
}