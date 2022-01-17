using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace WindowsFormsApp1
{
    public partial class EmployeeHome : Form
    {
        public EmployeeHome()
        {
            InitializeComponent();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void btnemployeehome_Click(object sender, EventArgs e)
        {
            employee.SetPage(0);
        }

        private void btnemployeeplaceorder_Click(object sender, EventArgs e)
        {
            cmbxitemcategory.AddItem("Dessert");
            cmbxitemcategory.AddItem("Fast Food");
            cmbxitemcategory.AddItem("Soup");
            cmbxitemcategory.AddItem("Drink");
            employee.SetPage(1);
        }

        private void btnsearchcategory_Click(object sender, EventArgs e)
        {
            List<Item> ilist = new List<Item>();
            Item i = new Item();
            
            if (cmbxitemcategory.selectedIndex!=-1)
            {
                ilist = i.getItembyCategory(cmbxitemcategory.selectedValue.ToString());
                foreach (Item it in ilist)
                {
                    listBoxitems.Items.Add(it.name);
                }
            }
            else
            {
                MessageBox.Show("Select any category");
            }
        }
    }
}
