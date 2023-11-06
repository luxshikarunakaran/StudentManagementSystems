using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace StudentManagementSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        string con = "datasource=127.0.0.1;port=3306;username=root;password=;database=student_management_system";

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure you want to close", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent Student=new AddStudent();
            Student.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ViewStudent View = new ViewStudent();
            View.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            EditRemove ER = new EditRemove();
            ER.Show();
        }

        private void viewStudentInFoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics Stat = new Statistics();
            Stat.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ManageStudents MS = new ManageStudents();
            MS.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            EditCourse EC =new EditCourse();
            EC.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AddCourse Course = new AddCourse();
            Course.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            RemoveCourse RC = new RemoveCourse();
            RC.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            ManageCourse MC = new ManageCourse();
            MC.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            AddScore AS = new AddScore();
            AS.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            EditRemoveScore ERS = new EditRemoveScore();
            ERS.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            ManageScoreInfo MSF = new ManageScoreInfo();
            MSF.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintStudent PStu= new PrintStudent();
            PStu.Show();
        }
    }
}
