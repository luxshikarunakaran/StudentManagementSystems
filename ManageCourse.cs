using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class ManageCourse : Form
    {

        private int currentRowIndex = 0;

        public ManageCourse()
        {
            InitializeComponent();
        }
        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void btnsaveInfo_Click(object sender, EventArgs e)
        {

            if (txtcid.Text == "" &&
                    txtdescription.Text == "" &&
                    txtlabel.Text == "" &&
                    txthour.Text == ""
                )
            {
                MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {
                Int32 CourseID = Convert.ToInt32(txtcid.Text);
                String CourseName = txtlabel.Text;
                Int32 NumberOfHours = Convert.ToInt32(txthour.Text);
                String Description = txtdescription.Text;

                string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlConnection conn = new MySqlConnection(con);

                string query = "INSERT INTO course(CourseID,CourseName,HoursNo,Description) VALUES ('" + CourseID + "','" + CourseName + "','" + NumberOfHours + "','" + Description + "')";

                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader myReader = queryCmd.ExecuteReader();
                conn.Close();

                ManageCourse_Load(this, null);

                MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ManageCourse_Load(object sender, EventArgs e)
        {

            AddCourse Course = new AddCourse();
            double totalCourse = Convert.ToDouble(Course.totalcourse());

            txtTotalCourse.Text = "Total Courses : " + totalCourse.ToString();



            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from course";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView11.DataSource = ds.Tables[0];

            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Int32 CourseID = Convert.ToInt32(txtcid.Text);
                String CourseName = txtlabel.Text;
                Int32 NumberOfHours = Convert.ToInt32(txthour.Text);
                String Description = txtdescription.Text;

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update course set CourseName='" + CourseName + "',HoursNo='" + NumberOfHours + "',Description='" + Description + "' where CourseID='" + txtcid.Text + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                ManageCourse_Load(this, null);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {


                string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlConnection conn = new MySqlConnection(con);

                string query = "delete from course where CourseID='" + txtcid.Text + "'";

                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader myReader = queryCmd.ExecuteReader();
                conn.Close();

                ManageCourse_Load(this, null);

                MessageBox.Show("Data Deleted  Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
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

                dataGridView11.DataSource = ds.Tables[0];
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        int CID;
        Int64 rowid;
        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                CID = int.Parse(dataGridView11.Rows[e.RowIndex].Cells[0].Value.ToString());
            }


            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from course where CourseID LIKE '" + txtCourseID.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtcid.Text = ds.Tables[0].Rows[0]["CourseID"].ToString();
            txtlabel.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
            txthour.Text = ds.Tables[0].Rows[0]["HoursNo"].ToString();
            txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

        }

        private void btnrefr_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to refresh?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtcid.Clear();
                txtCourseID.Clear();
                txtdescription.Clear();
                txtlabel.Clear();
                txthour.Clear();
            }
           
        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtCourseID.Text != "")
                {
                    int CID = Convert.ToInt32(txtCourseID.Text);

                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT CourseID,CourseName, HoursNo, Description FROM course WHERE CourseID='" + CID + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        txtcid.Text = ds.Tables[0].Rows[0]["CourseID"].ToString();
                        txtlabel.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                        txthour.Text = ds.Tables[0].Rows[0]["HoursNo"].ToString();
                        txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                        dataGridView11.DataSource = ds.Tables[0];
                    }
                }

            }
            catch
            {
                MessageBox.Show("Enter valid Course ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       

        private void btncourses_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(con))
            {
                connection.Open();
                string query = "SELECT CourseName FROM course";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string courseName = reader["CourseName"].ToString();
                            listBoxcourse.Items.Add(courseName);
                        }
                    }
                }
            }

        }


        // Increment and Decrement Course Details



        private void btnfirst_Click(object sender, EventArgs e)
        {
            



                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * from course";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                if (ds.Tables.Count > 0 && currentRowIndex < dataGridView11.Rows.Count)
                {
                    txtcid.Text = ds.Tables[0].Rows[0]["CourseID"].ToString();
                    txtlabel.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                    txthour.Text = ds.Tables[0].Rows[0]["HoursNo"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                    dataGridView11.ClearSelection();
                    dataGridView11.Rows[currentRowIndex].Selected = true;
                    currentRowIndex--;
                }
                
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT * from course";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);




                if (ds.Tables.Count > 0 && currentRowIndex < dataGridView11.Rows.Count)
                 {
                        txtcid.Text = ds.Tables[0].Rows[0]["CourseID"].ToString();
                        txtlabel.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                        txthour.Text = ds.Tables[0].Rows[0]["HoursNo"].ToString();
                        txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                        dataGridView11.ClearSelection();
                        dataGridView11.Rows[currentRowIndex].Selected = true;
                        currentRowIndex++;

                        
                }


               
                
         }

        private void btncoursedetails_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT *from course";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            dataGridView11.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillGrid(new MySqlCommand("select * from course"));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\course_list.xls";

            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                writer.Write("CourseID" + "\t" + "CourseName" + "\t" + "HoursNo" + "\t" + "Description");

                writer.WriteLine(" ");

                for (int i = 0; i < dataGridView11.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView11.Columns.Count; j++)
                    {
                        writer.Write(dataGridView11.Rows[i].Cells[j].Value.ToString() + "\t" + "  ");

                    }
                    writer.WriteLine(" ");

                }

                writer.Close();
                MessageBox.Show("Data Exported", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public void FillGrid(MySqlCommand command)
        {
            dataGridView11.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView11.RowTemplate.Height = 100;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT *from course";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView11.AllowUserToAddRows = false;

        }

    }
 }
