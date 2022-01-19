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
   public class UserInfo
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        private string query = "";

        DBHandler db = new DBHandler();

        public List<UserInfo> returnUsersList() {
            query = "select * from UserInfo";
            SqlDataReader sdr = db.getReader(query);
            List<UserInfo> ulist = new List<UserInfo>();
            UserInfo ui;
            while (sdr.Read())
            {
                ui = new UserInfo();
                ui.id = int.Parse(sdr["id"].ToString());
                ui.username = sdr["username"].ToString();
                ui.email = sdr["email"].ToString();
                ui.password = sdr["password"].ToString();
                ui.role = sdr["role"].ToString();
                ulist.Add(ui);   
            }
            db.CloseConnection();
            return ulist;
        }


        public bool matchcredentials(UserInfo user)
        {
            List<UserInfo> ulist = returnUsersList();
            List<UserInfo> ui = (from u in ulist where u.username == user.username && u.password.Equals(user.password) select u).ToList<UserInfo>();
            bool res=false;

            foreach (UserInfo u in ui)
            {
                if (u != null)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            return res;
        }

        public string returnRole(UserInfo user)
        {
            List<UserInfo> ulist = returnUsersList();
            List<UserInfo> ui = (from u in ulist where u.username == user.username select u).ToList<UserInfo>();
            string role = "";
            foreach (UserInfo u in ui)
            {
                if (u != null)
                {
                    role = u.role;
                }
                else
                {
                    role= "";
                }
            }
            return role;         
        }

        public bool addUser(UserInfo u)
        {
            if (checkvalidity(u.email, u.password))
            {
                string username = u.email.Split('@')[0];
                String query = "insert into userinfo(username, email, password, role) values('" + username + "', '" + u.email + "', '" + u.password + "', '" + u.role + "')";
                db.IDU(query);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deleteUser(String username)
        {
            string query = "delete from userInfo where username='"+username+"'";
            db.IDU(query); 
        }

        private bool checkvalidity(string email, string password)
        {
            bool res = false;
            string patternForEmail = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            string patternForPassword = @"^(?=.\d)(?=.[a-z])(?=.*[A-Z]).{8,25}$";
            if (Regex.IsMatch(email, patternForEmail) && Regex.IsMatch(password, patternForPassword))
            {
                res = true;
            }
            return res;
        }

        public UserInfo getUserbyUsername(string username)
        {
            List<UserInfo> ulist = returnUsersList();
            UserInfo ui = (from u in ulist where u.username == username select u).FirstOrDefault();
            return ui;
        }
       

    }
}
