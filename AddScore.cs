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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        int count;
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtstudentid.Text != "")
            {
                if (cmbcourse.SelectedIndex != -1 && count <= 2)
                {
                    int StudentID = Convert.ToInt32(txtstudentid.Text);
                    int Score = Convert.ToInt32(txtscore.Text);
                    String CourseName = cmbcourse.SelectedItem.ToString();
                    String Description = txtdescription.Text;


                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "insert into score (StudentID,CourseName,Score,Description) values ('" + StudentID + "','" + CourseName + "','" + Score + "','" + Description + "')";

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {

                        txtstudentid.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                        cmbcourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                        txtscore.Text = ds.Tables[0].Rows[0]["Score"].ToString();
                        txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                        dataGridView11.DataSource = ds.Tables[0];

                    }

                        MessageBox.Show("Score Details Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Course", "No course selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void AddScore_Load(object sender, EventArgs e)
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
            MySqlDataAdapter da = new MySqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            da.Fill(ds);

                dataGridView11.DataSource = ds.Tables[0];
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtstudentid.Clear();
            txtscore.Clear();
            txtdescription.Clear();
            cmbcourse.SelectedIndex = -1;
            txtenterenrollno.Clear();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
       
        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtstudentid.Text = dataGridView11.CurrentRow.Cells[0].Value.ToString();

        }

       
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

                    cmd.CommandText = "SELECT *from student where StudentID='"+txtenterenrollno.Text+"'";
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
    }
 }
 
    