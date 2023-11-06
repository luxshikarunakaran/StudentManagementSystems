using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }


       // string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void btnreferesh_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtStudentName.Clear();
            txtStuID.Clear();
            txtBirthDate.Clear();
            txtSid.Clear();
            txtgender.Clear();
            txtphoneNo.Clear();
           
        }

        private void txtenrollNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSid.Text != "")
            {
             
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from student";
                    // where StudentID LIKE '" + txtSid.Text + "%'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView11.DataSource = ds.Tables[0];
            }
            else
            {
                
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from student";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView11.DataSource = ds.Tables[0];
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Int64 SId = Convert.ToInt64(txtSId.Text);
                Int32 StudentID = Convert.ToInt32(txtStuID.Text);
                String Name = txtStudentName.Text;
                String DOB = txtBirthDate.Text;
                String PhoneNo = txtphoneNo.Text;
                String Address = txtaddress.Text;
                String Gender = txtgender.Text;
               // String Picture = pictureBox3.Image.ToString();

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update student set StudentID='" + StudentID + "', StudentName='" + Name + "',BirthDay='" + DOB + "',Gender='" + Gender + "',PhoneNo='" + PhoneNo + "',Address='" + Address + "' where StudentID='" +SId + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel21.Visible = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from student";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView11.DataSource = ds.Tables[0];
        }

        int SId;
        Int64 rowid;
        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                SId = int.Parse(dataGridView11.Rows[e.RowIndex].Cells[0].Value.ToString());
                //  MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel21.Visible = true;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from student where StudentID LIKE '" + txtSid.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtStuID.Text = ds.Tables[0].Rows[0][0].ToString();
            txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtBirthDate.Text = ds.Tables[0].Rows[0][2].ToString();
            txtgender.Text = ds.Tables[0].Rows[0][3].ToString();
            txtphoneNo.Text = ds.Tables[0].Rows[0][4].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
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

                ViewStudent_Load(this, null);

            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
