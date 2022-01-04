using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DBHandler
    {
        string dbpath = "";
        SqlConnection con;
        SqlCommand cmd;

        public DBHandler()
        {
            dbpath = @"Data Source=AMNA\SQLEXPRESS;Initial Catalog=CocosCafe;Integrated Security=True";
            con = new SqlConnection(dbpath);
        }
        private void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlDataReader getReader(string query)
        {
            OpenConnection();
            cmd = new SqlCommand(query, con);
            return cmd.ExecuteReader();
        }


        public void IDU(string query)
        {
            OpenConnection();
            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
