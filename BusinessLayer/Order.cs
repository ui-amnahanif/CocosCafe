using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class Order
    {
        public int id { get; set; }
        public string username { get; set; }
        public int employeeid { get; set; }
        public int price { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        private string query = "";

        DBHandler db = new DBHandler();
        public void insertOrder(Order o)
        {
            UserInfo ui = new UserInfo();
            ui = ui.getUserbyUsername(o.username);
            query = "insert into orderInfo(employeeid, price, date, time) values('" + ui.id + "', '" + o.price + "','" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "')";
            db.IDU(query);

        }

        public List<Order> returnOrderList()
        {
            query = "select * from OrderInfo";
            SqlDataReader sdr = db.getReader(query);
            List<Order> olist = new List<Order>();
            Order o;
            while (sdr.Read())
            {
                o = new Order();
                o.id = int.Parse(sdr["orderid"].ToString());
                o.employeeid = int.Parse(sdr["employeeid"].ToString());
                o.price = int.Parse(sdr["price"].ToString());
                o.date = sdr["date"].ToString();
                o.time = sdr["time"].ToString();
                olist.Add(o);
            }
            db.CloseConnection();
            return olist;
        }

    }
}
