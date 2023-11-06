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
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class EditCourse : Form
    {
        public EditCourse()
        {
            InitializeComponent();
        }

        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";


        int Cid;
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtcid.Text == "" &&
                  txtdescription.Text == "" &&
                  txtlabel.Text == "" &&
                  txthour.Text == ""
                  )
            {
                MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            else if(MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
               
                Int32 CourseID = Convert.ToInt32(txtcid.Text);
                String CourseName = txtlabel.Text;
                Int32 NumberOfHours = Convert.ToInt32(txthour.Text);
                String Description = txtdescription.Text;


                MySqlConnection conn = new MySqlConnection(con);
                string query = "UPDATE course SET CourseName='" +CourseName + "', HoursNo='" + NumberOfHours + "',Description='" + Description + "'  where CourseID='" + CourseID + "'";
                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader myReader = queryCmd.ExecuteReader();

                MessageBox.Show("Course Details Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {

            txtcid.Clear();
            txtdescription.Clear();
            txtlabel.Clear();
            txthour.Clear();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
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

        
    }
}
