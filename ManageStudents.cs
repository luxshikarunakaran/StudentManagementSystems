using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class ManageStudents : Form
    {
        public ManageStudents()
        {
            InitializeComponent();
        }

       string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void btnsaveInfo_Click(object sender, EventArgs e)
        {
           

                if (txtaddress.Text == "" &&
                    txtphoneno.Text == "" &&
                    txtSId.Text == "" &&
                    txtStuName.Text == "" &&
                    comboBox1.Text == null
                    )
                {
                    MessageBox.Show("Fill the data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else if (!Regex.IsMatch(txtphoneno.Text, @"^[0-9]{10}$"))
                {
                    MessageBox.Show("The contact No Should be 10 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                else
                {
                    Int32 StudentID = Convert.ToInt32(txtSId.Text);
                    String Name = txtStuName.Text;
                    String DOB = dateTimePickerDOB.Value.ToString();
                    String PhoneNo = txtphoneno.Text;
                    String Address = txtaddress.Text;
                    String Gender = comboBox1.SelectedItem.ToString();
                //String Picture = pictureBox3.Image.ToString();

                string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlConnection conn = new MySqlConnection(con);

                string query = "INSERT INTO student(StudentID,StudentName,BirthDay,Gender,PhoneNo,Address) VALUES ('" + StudentID + "','" + Name + "','" + DOB + "','" + Gender + "','" + PhoneNo + "','" + Address + "')";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();

                    ManageStudents_Load(this, null);

                   MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
        private void txtStudentID_TextChanged(object sender, EventArgs e)
        {
            try {

                if (txtStudentID.Text != "")
                {
                    int SID = Convert.ToInt32(txtStudentID.Text);

                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "SELECT StudentID,StudentName, BirthDay, Gender, PhoneNo, Address FROM student WHERE StudentID='" + SID + "'";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        txtSId.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                        txtStuName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                        dateTimePickerDOB.Text = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                        comboBox1.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                        txtphoneno.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                        txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                        dataGridView11.DataSource = ds.Tables[0];
                    }
                }            
            
            }
            catch
            {
                MessageBox.Show("Enter valid Student ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        int SId;
        Int64 rowid;

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView11.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                SId = int.Parse(dataGridView11.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from student where StudentID LIKE '" + txtSId.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtSId.Text = ds.Tables[0].Rows[0][0].ToString();
            txtStuName.Text = ds.Tables[0].Rows[0][1].ToString();
            dateTimePickerDOB.Text = ds.Tables[0].Rows[0][2].ToString();
            comboBox1.Text = ds.Tables[0].Rows[0][3].ToString();
            txtphoneno.Text = ds.Tables[0].Rows[0][4].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0][5].ToString();
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Int32 StudentID = Convert.ToInt32(txtSId.Text);
                String Name = txtStuName.Text;
                String DOB = dateTimePickerDOB.Value.ToString();
                String PhoneNo = txtphoneno.Text;
                String Address = txtaddress.Text;
                String Gender = comboBox1.SelectedItem.ToString();

                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update student set StudentID='" + StudentID + "',StudentName='" + Name + "',BirthDay='" + DOB + "',Gender='" + Gender + "',PhoneNo='" + PhoneNo + "',Address='" + Address + "' where StudentID='" + txtSId.Text + "'";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                ManageStudents_Load(this, null);
            }


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted? Confirm?.", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
               

                string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

                MySqlConnection conn = new MySqlConnection(con);

                string query = "delete from student where StudentID='"+txtSId.Text+"'";

                MySqlCommand queryCmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader myReader = queryCmd.ExecuteReader();
                conn.Close();

                ManageStudents_Load(this, null);

                MessageBox.Show("Data Deleted  Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnreferesh_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtphoneno.Clear();
            txtSId.Clear();
            txtStuName.Clear();
            dateTimePickerDOB.Value = DateTime.Today;
            comboBox1.SelectedIndex = -1;
            txtStudentID.Clear();
            //dataGridView11.Enabled= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox3.Image = new Bitmap(open.FileName);
                // image file path  
                pictureBox3.Text = open.FileName;

            }
        }

     

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
            
            int Sid = Convert.ToInt32(txtSId.Text);

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT StudentName, BirthDay, Gender, PhoneNo, Address FROM student WHERE StudentID='" + Sid + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    //   txtSId.Text = ds.Tables[0].Rows[0]["StudentID"].ToString();
                    txtStuName.Text = ds.Tables[0].Rows[0]["StudentName"].ToString();
                    dateTimePickerDOB.Text = ds.Tables[0].Rows[0]["BirthDay"].ToString();
                    comboBox1.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                    txtphoneno.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                    txtaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();

                    dataGridView11.DataSource = ds.Tables[0];
                }
        }
          
        

        private void ManageStudents_Load(object sender, EventArgs e)
        {


            //display the values

            AddStudent Student = new AddStudent();
            double totalStudents = Convert.ToDouble(Student.totalStudent());
            double totalMaleStudents = Convert.ToDouble(Student.totalMaleStudent());
            double totalFemaleStudents = Convert.ToDouble(Student.totalFemaleStudent());

            // count the %

            double malePercentage = totalMaleStudents * 100 / totalStudents;
            double femalePercentage = totalFemaleStudents * 100 / totalStudents;

            labelTotalStudent.Text = "Total Students : " + totalStudents.ToString();
            labelMaleStudents.Text = "Male Students : " + totalMaleStudents.ToString();
            labelFemaleStudents.Text = "Female Students : " + totalFemaleStudents.ToString();


            //panel3.Visible = true;

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

     
        private void txtStudentID_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtStudentID.Text == "")
            {
                txtStudentID.BackColor = Color.Green;

            }
            else
            {
                txtStudentID.BackColor = Color.Red;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = "Student :" + txtSId.Text;

            if (pictureBox3.Image == null)
            {
                MessageBox.Show("No Image in the Box","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if(svf.ShowDialog()== DialogResult.OK)
            {
                pictureBox3.Image.Save(svf.FileName+("'."+ImageFormat.Jpeg.ToString()));
            }
        }

        private void btnstudentdatils_Click(object sender, EventArgs e)
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FillGrid(new MySqlCommand("select * from student"));

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\students_list.xls";

            using(var writer=new StreamWriter(path))
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }

                writer.Write("StudentID" + "\t" + "StudentName" + "\t" + "BirthDay" + "\t" + "Gender"+"\t"+"PhoneNo"+"\t"+"Address");
                writer.WriteLine(" ");

                for (int i=0;i<dataGridView11.Rows.Count;i++)
                {
                    for(int j=0;j<dataGridView11.Columns.Count;j++)
                    {
                        writer.Write(dataGridView11.Rows[i].Cells[j].Value.ToString()+"\t"+" ");
                        
                    }
                    writer.WriteLine(" ");

                }

                writer.Close();
                MessageBox.Show("Data Exported","Export",MessageBoxButtons.OK,MessageBoxIcon.Information);

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

            cmd.CommandText = "SELECT *from student";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

          

            // picCol = (DataGridViewImageColumn)dataGridView11.Columns[6];
            // picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView11.AllowUserToAddRows= false;

            labelTotalStudent.Text = "Total Student : " + dataGridView11.Rows.Count;
        }
    }
}

