using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class Staff
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        private string query = "";

        DBHandler db = new DBHandler();

        public List<Staff> getStaff()
        {
            query = "select * from UserInfo ";
            SqlDataReader sdr = db.getReader(query);
            List<Staff> slist = new List<Staff>();
            Staff s;
            while(sdr.Read())
            {
                s= new Staff();
                s.id = int.Parse(sdr["id"].ToString());
                s.username = sdr["username"].ToString();
                s.email = sdr["email"].ToString();
                s.password = sdr["password"].ToString();
                s.role = sdr["role"].ToString(); 
                slist.Add(s);
            }
            db.CloseConnection();
            return slist;
        }
    }
}
