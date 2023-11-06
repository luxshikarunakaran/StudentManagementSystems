using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }
        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
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
                    Int32 NumberOfHours =Convert.ToInt32(txthour.Text);
                    String Description = txtdescription.Text;


                    MySqlConnection conn = new MySqlConnection(con);
                    string query = "INSERT INTO course(CourseID,CourseName,HoursNo,Description) VALUES ('" + CourseID + "','" + CourseName + "','" + NumberOfHours + "','" + Description + "')";

                    MySqlCommand queryCmd = new MySqlCommand(query, conn);

                    conn.Open();

                    MySqlDataReader myReader = queryCmd.ExecuteReader();
                    conn.Close();


                    MessageBox.Show("Course Details Saved Successfully!", "Course Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Somethig wrong Checked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


        public string execCount(string query)
        {
            MySqlConnection conn = new MySqlConnection(con);

            MySqlCommand command = new MySqlCommand(query, conn);
            conn.Open();

            string count = command.ExecuteScalar().ToString();
            conn.Close();

            return count;
        }

        // get the total students

        public string totalcourse()
        {
            return execCount("Select Count(*) from course");
        }


    }

   
}


