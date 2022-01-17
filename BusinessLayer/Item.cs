using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data.SqlClient;
namespace BusinessLayer
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }

        private string query = "";

        DBHandler db = new DBHandler();

        public List<Item> returnItemsList()
        {
            query = "select * from Item";
            SqlDataReader sdr = db.getReader(query);
            List<Item> ilist = new List<Item>();
            Item i;
            while (sdr.Read())
            {
                i = new Item();
                i.id = int.Parse(sdr["id"].ToString());
                i.name = sdr["name"].ToString();
                i.category = sdr["category"].ToString();
                i.price = int.Parse(sdr["price"].ToString());
                i.quantity = int.Parse(sdr["quantity"].ToString());
                ilist.Add(i);
            }
            db.CloseConnection();
            return ilist;
        }

        public void addItem(Item i)
        {
            String query = "insert into Item(name, category, price, quantity) values('" + i.name + "', '" + i.category + "', '" + i.price + "', '" + i.quantity + "')";
            db.IDU(query);

        }

        public void deleteItem(int id)
        {
            string query = "delete from item where id='" + id + "'";
            db.IDU(query);
        }

        public Item getItembyId(int id)
        {
            List<Item> ilist = returnItemsList();
            Item itm = (from i in ilist where i.id == id select i).FirstOrDefault();
            return itm;
        }

        public bool updateItem(Item i)
        {
            Item it = getItembyId(i.id);
            if (it!=null)
            {
                String query = "Update Item set name ='" + i.name + "',category ='" + i.category + "',price= '" + i.price + "',quantity= '" + i.quantity + "'";
                db.IDU(query);
                return true;
            }
            else
            {
                return false;
            }
           

        }
    }
}
