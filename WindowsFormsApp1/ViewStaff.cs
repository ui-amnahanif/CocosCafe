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
    public partial class ViewStaff : Form
    {
        public ViewStaff()
        {
            InitializeComponent();
        }

     


        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void btnviewstaff_Click(object sender, EventArgs e)
        {
            dgvstaff.Rows.Clear();
            Staff s = new Staff();
            List<Staff> slist = s.getStaff();
            foreach(Staff st in slist)
            {
                dgvstaff.Rows.Add(st.id, st.username, st.email, st.password, st.role);
            }


        }

        private void ViewStaff_Load(object sender, EventArgs e)
        {
           
            dgvstaff.Rows.Clear();
            Staff s = new Staff();
            List<Staff> slist = s.getStaff();
            foreach (Staff st in slist)
            {
                dgvstaff.Rows.Add(st.id, st.username, st.email, st.password, st.role);
            }
        }
    }
}
