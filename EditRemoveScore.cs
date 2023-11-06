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
    public partial class EditRemoveScore : Form
    {
        public EditRemoveScore()
        {
            InitializeComponent();
        }
       string con= "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";
        private void txtenterenrollno_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtenterenrollno.Text != "")
                {
                    int CID = Convert.ToInt32(txtenterenrollno.Text);

                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT *from student where StudentID='" + txtenterenrollno.Text + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);


                    dataGridView11.DataSource = ds.Tables[0];

                }

            }
            catch
            {
                MessageBox.Show("Enter valid Course ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnallStudent_Click(object sender, EventArgs e)
        {

            try
            {

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT *from student";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridView11.DataSource = ds.Tables[0];
              //  txtstudentid.Text = dataGridView11.CurrentRow.Cells[0].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Enter valid Course ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtstudentid.Clear();
            txtscore.Clear();
            txtdescription.Clear();
            cmbcourse.SelectedIndex = -1;
            txtenterenrollno.Clear();
        }

      
        private void EditRemoveScore_Load(object sender, EventArgs e)
        {
            
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new MySqlCommand("select CourseName from course", con);
            MySqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {
                for (int i = 0; i < sdr.FieldCount; i++)
                {
                    cmbcourse.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();

            string query = "select StudentID,StudentName,Birthday,Gender,PhoneNo,Address from student";
            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView11.DataSource = ds.Tables[0];


            string query1 = "select StudentID,CourseName,Score,Description from score";
            MySqlDataAdapter da1 = new MySqlDataAdapter(query1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridViewscore.DataSource = ds1.Tables[0];

        }


        private void btnedit_Click(object sender, EventArgs e)
        {
          
              if (txtstudentid.Text == "" &&
                 txtdescription.Text == "" &&
                 txtscore.Text == "" &&
                 cmbcourse.SelectedIndex == -1
                 )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                else if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    Int32 StudentID = Convert.ToInt32(txtstudentid.Text);
                    String CourseName = cmbcourse.SelectedItem.ToString();
                    Int32 Score = Convert.ToInt32(txtscore.Text);
                    String Description = txtdescription.Text;


                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "UPDATE score SET StudentID='" + StudentID + "', CourseName='" + CourseName + "',Score='" + Score + "',Description='" + Description + "'  where StudentID='" + StudentID + "'";
                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();

                    MessageBox.Show("Score Details Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
        

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from score where StudentID='" + txtstudentid.Text + "'";
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
              // dataGridViewscore.DataSource = ds1.Tables[0];


            }
        }

        private void dataGridViewscore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           txtstudentid.Text = dataGridViewscore.CurrentRow.Cells[0].Value.ToString();
           

            
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
           
                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT StudentID,CourseName, Score, Description FROM score WHERE StudentID='" + txtstudentid.Text + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        txtstudentid.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                        cmbcourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                        txtscore.Text = ds.Tables[0].Rows[0]["Score"].ToString();
                        txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                        dataGridViewscore.DataSource = ds.Tables[0];
                    }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT *from score";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                dataGridViewscore.DataSource = ds.Tables[0];

            }
            catch
            {
                MessageBox.Show("Enter valid Course ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

       
}
