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
    public partial class ManagerHome : Form
    {
        public ManagerHome()
        {
            InitializeComponent();
        }

        private void btnviewstaff_Click(object sender, EventArgs e)
        {
            welcome.SetPage(1);
            dgvaddstaff.Rows.Clear();
            UserInfo u = new UserInfo();
            List<UserInfo> ulist = u.returnUsersList();
            foreach (UserInfo st in ulist)
            {
                dgvaddstaff.Rows.Add(st.id, st.username, st.email, st.password, st.role);
            }
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

       

        private void btnaddstaff_Click(object sender, EventArgs e)
        {
           
            welcome.SetPage(2);
        }

        private void lbllogo_Click(object sender, EventArgs e)
        {
            welcome.SetPage(0);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            welcome.SetPage(3);
           
        }

        private void btnviewitems_Click(object sender, EventArgs e)
        {
            welcome.SetPage(4);
            dgvviewitem.Rows.Clear();
            Item i = new Item();
            List<Item> ilist = i.returnItemsList();
            foreach (Item it in ilist)
            {
                dgvviewitem.Rows.Add(it.id, it.name, it.category, it.price, it.quantity);
            }
            
        }

        private void btnadditems_Click(object sender, EventArgs e)
        {
            cmbxadditemcategory.Clear();
            cmbxadditemcategory.AddItem("Dessert");
            cmbxadditemcategory.AddItem("Fast Food");
            cmbxadditemcategory.AddItem("Soup");
            cmbxadditemcategory.AddItem("Drink");
            welcome.SetPage(5);
        }

        private void btnupdateitems_Click(object sender, EventArgs e)
        {
            cmbxupdateitemcategory.Clear();
            cmbxupdateitemcategory.AddItem("Dessert");
            cmbxupdateitemcategory.AddItem("Fast Food");
            cmbxupdateitemcategory.AddItem("Soup");
            cmbxupdateitemcategory.AddItem("Drink");
            welcome.SetPage(6);
        }

        private void btnremoveitems_Click(object sender, EventArgs e)
        {
            welcome.SetPage(7);
        }

        private void btnvieworders_Click(object sender, EventArgs e)
        {
            welcome.SetPage(8);
            dgvvieworder.Rows.Clear();
            List<Order> olist = new List<Order>();
            Order o = new Order();
            olist = o.returnOrderList();
            foreach (Order oi in olist)
            {
                dgvvieworder.Rows.Add(oi.id, oi.employeeid, oi.price, oi.date, oi.time);
            }
           
        }

        private void btnstaffsearch_Click(object sender, EventArgs e)
        {
            dgvdeletestaff.Rows.Clear();
            UserInfo u = new UserInfo();
            UserInfo ui = u.getUserbyUsername(txtsearchstaffusername.Text);
            if (ui!=null)
            {
                dgvdeletestaff.Rows.Add(ui.id, ui.username, ui.email, ui.password, ui.role);
            }
            else
            {
                MessageBox.Show("This username doesn't exist");
            }

        }

        private void btnadduser_Click(object sender, EventArgs e)
        {
            UserInfo u = new UserInfo();
            u.email = txtstaffemail.Text;
            u.password = txtstaffpassword.Text;
            if (rdbtnroleemployee.Checked)
            {
                u.role = rdbtnroleemployee.Text;
            }
            else
            {
                u.role = rdbtnrolemanager.Text;
            }
            if (u.addUser(u))
            {
                MessageBox.Show("Staff added successfully");
            }
            else
            {
                MessageBox.Show("Email must contain . . .\n Password must contain . . .");
            }
        }

        private void dgvdeletestaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdeletestaff.Rows[e.RowIndex];
            //MessageBox.Show(row.Cells[1].Value.ToString());
            string username = row.Cells[1].Value.ToString();
            UserInfo u = new UserInfo();
            u.deleteUser(username);
            dgvdeletestaff.Rows.RemoveAt(e.RowIndex);

        }

        private void btnsearchitemid_Click(object sender, EventArgs e)
        {
            dgvdeleteitem.Rows.Clear();
            Item i = new Item();
            Item it = i.getItembyId(int.Parse(txtsearchitemid.Text));
            if (it != null)
            {
                dgvdeleteitem.Rows.Add(it.id,it.name,it.category,it.price,it.quantity);
            }
            else
            {
                MessageBox.Show("This id doesn't exist");
            }
        }

        private void btnadditem_Click(object sender, EventArgs e)
        {
            Item i = new Item();
            if (txtadditemname.Text!=null)
            {
                i.name = txtadditemname.Text;
                if (cmbxadditemcategory.selectedValue!=null)
                {
                    i.category = cmbxadditemcategory.selectedValue.ToString();
                    if (txtadditemprice.Text != null)
                    {
                        i.price = int.Parse(txtadditemprice.Text);
                        if (txtadditemqty.Text != null)
                        {
                            i.quantity= int.Parse(txtadditemqty.Text);
                            i.addItem(i);
                            MessageBox.Show("Added Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Enter Item Quantity");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Item Price");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Item Category");
                }
            }
            else
            {
                MessageBox.Show("Enter Item Name");
            }
        }

        private void dgvdeleteitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvdeleteitem.Rows[e.RowIndex];
            //MessageBox.Show(row.Cells[1].Value.ToString());
            string id = row.Cells[0].Value.ToString();
            Item i = new Item();
            i.deleteItem(int.Parse(id));
            dgvdeleteitem.Rows.RemoveAt(e.RowIndex);
        }

        private void btnupdateitem_Click(object sender, EventArgs e)
        {
            Item i = new Item();
            if(txtupdateitemid.Text != null)
            {
                i.id = int.Parse(txtupdateitemid.Text);
                if (txtupdateitemname.Text != null)
                {
                    i.name = txtupdateitemname.Text;
                    if (cmbxupdateitemcategory.selectedValue != null && cmbxupdateitemcategory.selectedIndex != -1)
                    {
                        i.category = cmbxupdateitemcategory.selectedValue.ToString();
                        if (txtupdateitemprice.Text != null)
                        {
                            i.price = int.Parse(txtupdateitemprice.Text);
                            if (txtupdateitemqty.Text != null)
                            {
                                i.quantity = int.Parse(txtupdateitemqty.Text);
                                if (i.updateItem(i))
                                {
                                    MessageBox.Show("Updated Successfully");
                                }
                                else
                                {
                                    MessageBox.Show("this id doesn't exist");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Enter Item Quantity");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Enter Item Price");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Item Category");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Item Name");
                }
            }
            else
            {
                MessageBox.Show("Enter Item ID");
            }

        }
    }
}
