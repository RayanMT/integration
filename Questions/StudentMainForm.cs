using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PROJECT
{
    public partial class StudentMainForm : Form
    {
        public StudentMainForm()
        {
            InitializeComponent();
            this.Load += StudentMainForm_Load;
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var examForm = new ExamForm();
            examForm.FormClosed += (s, args) => this.Show();
            examForm.Show();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradeTracker gradeForm = new GradeTracker();
            gradeForm.FormClosed += (s, args) => this.Show(); // So it goes back to this form when closed
            gradeForm.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                                      "Exit Confirmation",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
