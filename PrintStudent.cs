using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class PrintStudent : Form
    {
        private MySqlConnection connection;
        private string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";
        public PrintStudent()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);

        }

        private void PrintStudent_Load(object sender, EventArgs e)
        {
            
       

                try
                {
                    connection.Open();

                    // Fetch course details from the database
                    string query = "SELECT CourseName, Score, Description FROM score WHERE StudentID=1";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader["CourseName"].ToString();
                        textBox2.Text = reader["Instructor"].ToString();
                        textBox3.Text = reader["Schedule"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

