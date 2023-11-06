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
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class EditRemove : Form
    {
        public EditRemove()
        {
            InitializeComponent();
        }
        int SId;
        Int64 rowid;
      

        private void btnsaveInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Int64 SId = Convert.ToInt64(txtSId.Text);
                Int32 StudentID = Convert.ToInt32(txtSId.Text);
                String Name = txtStuName.Text;
                String DOB = txtDOB.Text;
                String PhoneNo = txtphoneno.Text;
                String Address = txtaddress.Text;
                String Gender = txtgender.Text;
                // String Picture = pictureBox3.Image.ToString();

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update student set StudentID='" + StudentID + "', StudentName='" + Name + "',BirthDay='" + DOB + "',Gender='" + Gender + "',PhoneNo='" + PhoneNo + "',Address='" + Address + "' where StudentID='" + SId + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
        }

        private void btnrefersh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from student where StudentID='" + SId + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtStuName.Clear();
            txtSId.Clear();
            txtDOB.Clear();
            txtgender.Clear();
            txtphoneno.Clear();
            
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            int Sid = Convert.ToInt32(txtSId.Text);

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT StudentName, BirthDay, Gender, PhoneNo, Address FROM student WHERE StudentID='"+Sid+"'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
               // txtSId.Text = ds.Tables[0].Rows[0][0].ToString();
                txtStuName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                txtDOB.Text = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                txtgender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                txtphoneno.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
            }

        }
    }
}
