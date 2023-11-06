using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace StudentManagementSystem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";
        

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure You want to Exit?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnrefersh_Click(object sender, EventArgs e)
        {
            txtaddress.Clear();
            txtphoneno.Clear();
            txtSId.Clear();
            txtStuName.Clear();
            dateTimePickerDOB.Value = DateTime.Today;
            comboBox1.SelectedIndex = -1;
        }

        private void btnsaveInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtaddress.Text == "" &&
                    txtphoneno.Text == "" &&
                    txtSId.Text == "" &&
                    txtStuName.Text == "" &&
                    comboBox1.Text==null 
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

                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO student(StudentID,StudentName,BirthDay,Gender,PhoneNo,Address) VALUES ('" + StudentID + "','" + Name + "','" + DOB + "','" + Gender + "','" + PhoneNo + "','" + Address + "')";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Data Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch
            {
                MessageBox.Show("Something Error Check the data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create a function to return a table of students data

       
        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog OPF =new OpenFileDialog();
            //OPF.Filter = "Select Image(*.jpg;*.png;*.gif)*.jpg;*.png;*.gif";

            //if(OPF.ShowDialog()==DialogResult.OK)
            //{
            //    pictureBox3.Image = Image.FromFile(OPF.FileName);
            //}

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

        // Create a function to execute the count queries

        public string execCount(string query)
        {
            MySqlConnection conn = new MySqlConnection(con);

            MySqlCommand command =new MySqlCommand(query,conn);
            conn.Open();

            string count = command.ExecuteScalar().ToString();
            conn.Close();

            return count;
        }

        // get the total students

        public string totalStudent()
        {
            return execCount("Select Count(*) from student");
        }

        // get the total male students

        public string totalMaleStudent()
        {
            return execCount("Select Count(*) from student where Gender='Male'");
        }

        // get the total female students

        public string totalFemaleStudent()
        {
            return execCount("Select Count(*) from student where Gender='Female'");
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
