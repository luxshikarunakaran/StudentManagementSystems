using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class RemoveCourse : Form
    {
        public RemoveCourse()
        {
            InitializeComponent();
        }
        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtcid.Clear();
            txtdescription.Clear();
            txtlabel.Clear();
            txthour.Clear();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            int CID = Convert.ToInt32(txtcid.Text);

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT CourseName, HoursNo, Description FROM course WHERE CourseID='" + CID + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                txtlabel.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                txthour.Text = ds.Tables[0].Rows[0]["HoursNo"].ToString();
                txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
            }

        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MySqlConnection conCmd = new MySqlConnection(con);
                string query1 = "DELETE From course where CourseID='" + txtcid.Text + "'";
                MySqlCommand queryCmd = new MySqlCommand(query1, conCmd);

                conCmd.Open();

                MySqlDataReader myReader = queryCmd.ExecuteReader();

                MessageBox.Show(" Course succesfully Deleted","Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);



            }
        }
    }
}
