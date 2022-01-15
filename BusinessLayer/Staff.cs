using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

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

        //public List<Staff> getStaffByUsername()
        //{
        //    List<UserInfo> slist = returnUsersList();
        //    List<UserInfo> ui = (from u in ulist where u.username == user.username && u.password.Equals(user.password) select u).ToList<UserInfo>();
           
        //    return slist;
        //}

        public bool addStaff(Staff s)
        {
           if( checkvalidity(s.email, s.password)){
                string username = s.email.Split('@')[0];
                String query = "insert into userinfo(username, email, password, role) values('" + username + "', '" + s.email + "', '" + s.password + "', '" + s.role + "')";
                db.IDU(query);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkvalidity(string email, string password)
        {
            bool res = false;
            string patternForEmail = "";
            string patternForPassword = "";
            if (Regex.IsMatch(email, patternForEmail) && Regex.IsMatch(password, patternForPassword))
            {
                res = true;
            }
            return res;
        }
    }
}
