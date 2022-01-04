using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;

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

        private UserInfo SearchUserbyUserName(string username)
        {
            query = "select * from UserInfo where username='" + username + "'";
            SqlDataReader sdr = db.getReader(query);
            UserInfo ui = new UserInfo();
            if (sdr.Read())
            {
                ui.id = int.Parse(sdr["id"].ToString());
                ui.username = sdr["username"].ToString();
                ui.email = sdr["email"].ToString();
                ui.password = sdr["password"].ToString();
                ui.role = sdr["role"].ToString();
                db.CloseConnection();
                return ui;
            }
            else
            {
                db.CloseConnection();
                return null;
            }


        }

        public bool matchcredentials(UserInfo u)
        {
            UserInfo ui = SearchUserbyUserName(u.username);
            if (ui == null)
            {
                return false;
            }
            else
            {
                if (ui.username.Equals(u.username) && ui.password.Equals(u.password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public string returnRole(UserInfo ui)
        {
            UserInfo u = SearchUserbyUserName(ui.username);
            if (u == null)
            {
                return "";
            }
            else
            {
                return u.role;
            }
           
        }


    }
}
