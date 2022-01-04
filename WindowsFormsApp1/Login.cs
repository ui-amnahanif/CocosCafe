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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

      

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp su = new SignUp();
            su.Show();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            UserInfo ui = new UserInfo();
            ui.username = txtusername.Text;
            ui.password = txtpassword.Text;
            if (ui.matchcredentials(ui))
            {
                string role = ui.returnRole(ui);
                if (role == "Manager")
                {
                    this.Hide();
                    ManagerHome mh = new ManagerHome();
                    mh.Show();
                }
                else
                {
                    this.Hide();
                    EmployeeHome eh = new EmployeeHome();
                    eh.Show();
                }
            }
            else
            {
                MessageBox.Show("Credential Not Mached");
            }
        }
    }
}
