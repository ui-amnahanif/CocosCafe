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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class EmployeeHome : Form
    {
        string employeeusername = null;
        public EmployeeHome(string username)
        {
            InitializeComponent();
            employeeusername = username;
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
            cmbxitemcategory.Clear();
            listBoxitems.Items.Clear();
            txtitemid.Clear();
            txtitemname.Clear();
            txtitemprice.Clear();
            txtitemqty.Clear();
            txtitemtotal.Clear();
            dgvplaceorder.Rows.Clear();
            txtgrandtotal.Clear();
            cmbxitemcategory.AddItem("Dessert");
            cmbxitemcategory.AddItem("Fast Food");
            cmbxitemcategory.AddItem("Soup");
            cmbxitemcategory.AddItem("Drink");
            employee.SetPage(1);
        }

        private void btnsearchcategory_Click(object sender, EventArgs e)
        {
            listBoxitems.Items.Clear();
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

        private void listBoxitems_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtitemname.Enabled = false;
            txtitemprice.Enabled = false;
            txtitemid.Enabled = false;
            Item i = new Item();
            i = i.getItemByNameAndCategory(listBoxitems.SelectedItem.ToString(),cmbxitemcategory.selectedValue);
            txtitemid.Text = i.id.ToString();
            txtitemname.Text = i.name;
            txtitemprice.Text = i.price.ToString();

           // MessageBox.Show(i.name+i.category+i.id+i.price+i.quantity);
        }

        //mistakenly added ------------------------------

        private void txtitemname_TextChanged(object sender, EventArgs e)
        {

        }
        // ----------------------------------------------

        private void txtitemqty_TextChange(object sender, EventArgs e)
        {
            txtitemtotal.Enabled = false;
            if (Regex.IsMatch(txtitemqty.Text, "\\d"))
            {
                txtitemtotal.Text = (int.Parse(txtitemqty.Text) * int.Parse(txtitemprice.Text)).ToString();
            }  
        }

        private void btnaddtocart_Click(object sender, EventArgs e)
        {
            dgvplaceorder.Rows.Add(txtitemid.Text,txtitemname.Text,txtitemprice.Text, txtitemqty.Text,txtitemtotal.Text);
        }

        private void dgvplaceorder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvplaceorder.Rows.RemoveAt(e.RowIndex);
        }

        private void dgvplaceorder_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridView row in dgvplaceorder.Rows)
            {
                row.CurrentCell.Value.ToString();
            }
        }
    }
}
