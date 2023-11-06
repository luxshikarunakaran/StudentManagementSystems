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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace StudentManagementSystem
{
    public partial class ManageScoreInfo : Form
    {
        private int currentRowIndex = 0;

        public ManageScoreInfo()
        {
            InitializeComponent();
        }
        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        int count;
        private void btnadd_Click(object sender, EventArgs e)
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

                        dataGridViewscore.DataSource = ds.Tables[0];

                    }

                    MessageBox.Show("Score Details Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Course", "No course selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
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

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtstudentid.Clear();
            txtscore.Clear();
            txtdescription.Clear();
            cmbcourse.SelectedIndex = -1;
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

        private void dataGridViewscore_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtstudentid.Text = dataGridViewscore.CurrentRow.Cells[0].Value.ToString();

          
        }

        private void ManageScoreInfo_Load(object sender, EventArgs e)
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

            
            string query1 = "select StudentID,CourseName,Score,Description from score";
            MySqlDataAdapter da1 = new MySqlDataAdapter(query1, con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridViewscore.DataSource = ds1.Tables[0];
        }

        private void btncourses_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(con))
            {
                connection.Open();
                string query = "SELECT StudentID,Score FROM score";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string StudentID = reader["StudentID"].ToString();
                            string Score = reader["Score"].ToString();

                            listBox1.Items.Add("StudentID : " +"\n" +StudentID+"\t"+ "Score : "+"\n\t"+Score);

                        }
                    }
                }
            }
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * from score";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds.Tables.Count > 0 && currentRowIndex < dataGridViewscore.Rows.Count)
            {
                txtstudentid.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                cmbcourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                txtscore.Text = ds.Tables[0].Rows[0]["Score"].ToString();
                txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                dataGridViewscore.ClearSelection();
                dataGridViewscore.Rows[currentRowIndex].Selected = true;
                currentRowIndex--;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * from score";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            if (ds.Tables.Count > 0 && currentRowIndex < dataGridViewscore.Rows.Count)
            {
                txtstudentid.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                cmbcourse.Text = ds.Tables[0].Rows[0]["CourseName"].ToString();
                txtscore.Text = ds.Tables[0].Rows[0]["Score"].ToString();
                txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();

                dataGridViewscore.ClearSelection();
                dataGridViewscore.Rows[currentRowIndex].Selected = true;
                currentRowIndex++;

            }
        }

        private void btnaveragescore_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT course.CourseName,avg(score.Score) as 'Average Score' from course,score where course.CourseID=score.StudentID group by course.CourseName";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridViewAvg.DataSource = ds.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            FillGrid(new MySqlCommand("select * from score"));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\score_list.xls";

            using (var writer = new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                writer.Write("StudentID"+"\t"+ "CourseName"+"\t"+ "Score"+"\t"+ "Description");
               

                writer.WriteLine(" ");

                for (int i = 0; i < dataGridViewscore.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewscore.Columns.Count; j++)
                    {
                        writer.Write(dataGridViewscore.Rows[i].Cells[j].Value.ToString() + "\t" + " ");

                    }
                    writer.WriteLine(" ");

                }

                writer.WriteLine(" ");
                writer.Write("CourseName" + "\t" + "Score" + "\t");
                writer.WriteLine(" ");


                for (int i = 0; i < dataGridViewAvg.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewAvg.Columns.Count; j++)
                    {
                        writer.Write(dataGridViewAvg.Rows[i].Cells[j].Value.ToString() + "\t" + " ");

                    }
                    writer.WriteLine(" ");

                }

                writer.Close();
                MessageBox.Show("Data Exported", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }


        public void FillGrid(MySqlCommand command)
        {
            dataGridViewscore.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridViewscore.RowTemplate.Height = 100;

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT *from score";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);



            // picCol = (DataGridViewImageColumn)dataGridView11.Columns[6];
            // picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewscore.AllowUserToAddRows = false;
            dataGridViewAvg.AllowUserToAddRows = false;
        }

        private void dataGridViewAvg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbcourse.Text = dataGridViewAvg.CurrentRow.Cells[0].Value.ToString();

        }
    }
}

