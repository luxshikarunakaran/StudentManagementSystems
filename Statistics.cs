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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }


        // Color variables

        Color panelTotalColor;
        Color PanelMaleColor;
        Color PanelFemaleColor;
        private void Statistics_Load(object sender, EventArgs e)
        {
            // get panels color

            panelTotalColor = panelTotal.BackColor;
            PanelMaleColor=panelMale.BackColor;
            PanelFemaleColor=panelFemale.BackColor;


            //display the values

            AddStudent Student=new AddStudent();
            double totalStudents = Convert.ToDouble(Student.totalStudent());
            double totalMaleStudents = Convert.ToDouble(Student.totalMaleStudent());
            double totalFemaleStudents = Convert.ToDouble(Student.totalFemaleStudent());

            // count the %

            double malePercentage = totalMaleStudents * 100 / totalStudents;
            double femalePercentage = totalFemaleStudents * 100 / totalStudents;

            label2.Text = "Total Students : " + totalStudents.ToString();
            labelMale.Text="Male Students : "+totalMaleStudents.ToString();
            labelFemale.Text = "Female Students : " + totalFemaleStudents.ToString();

        }


        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panelTotal.BackColor = Color.Silver;
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panelTotal.BackColor = Color.Brown;
            label2.ForeColor = Color.SandyBrown;
        
        }

        private void labelMale_MouseEnter(object sender, EventArgs e)
        {
            panelMale.BackColor = Color.WhiteSmoke;
            labelMale.ForeColor = Color.Tomato;
        }

        private void labelMale_MouseLeave(object sender, EventArgs e)
        {
            panelMale.BackColor = Color.SeaGreen;
            labelMale.ForeColor = Color.Thistle;
        }

        private void labelFemale_MouseEnter(object sender, EventArgs e)
        {
            panelFemale.BackColor = Color.PaleVioletRed;
            labelFemale.ForeColor = Color.MistyRose;
        }

        private void labelFemale_MouseLeave(object sender, EventArgs e)
        {
            panelFemale.BackColor = Color.Gainsboro;
            labelFemale.ForeColor = Color.SandyBrown;
        }

       
    }
}
