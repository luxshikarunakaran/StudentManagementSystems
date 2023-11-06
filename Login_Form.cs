using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";


        private void btnlogin_Click(object sender, EventArgs e)
        {
            String username = Convert.ToString(txtusername.Text);
            String password = Convert.ToString(txtpassword.Text);

            if (username == "")
            {
                MessageBox.Show("Enter the username ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password == "")
            {
                MessageBox.Show("Enter the password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                MySqlConnection conn = new MySqlConnection();

                string query = "SELECT * FROM login where Username='" + txtusername.Text + "' and Password='" + txtpassword.Text + "'";
                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();

                Login_Form login = new Login_Form();
                login.Hide();
            }
        }

        private void txtusername_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Clear();
            }
        }

        private void txtpassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Clear();
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBoxInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");

        }

        private void pictureBoxfacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://web.facebook.com/?_rdc=1&_rdr");

        }

        private void pictureBoxYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");

        }
    }
}
