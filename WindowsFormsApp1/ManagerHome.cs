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
            Staff s = new Staff();
            List<Staff> slist = s.getStaff();
            foreach (Staff st in slist)
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
        }

        private void btnadditems_Click(object sender, EventArgs e)
        {
            welcome.SetPage(5);
        }

        private void btnupdateitems_Click(object sender, EventArgs e)
        {
            welcome.SetPage(6);
        }

        private void btnremoveitems_Click(object sender, EventArgs e)
        {
            welcome.SetPage(7);
        }

        private void btnvieworders_Click(object sender, EventArgs e)
        {
            welcome.SetPage(8);
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
    }
}
