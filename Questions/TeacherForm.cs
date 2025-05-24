using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamSystem_New;

namespace PROJECT
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
            this.Load += TeacherForm_Load;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ControlBox = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.OpenAddQuestion(); // Directly open the Add Question window
            this.Hide();
            mf.FormClosed += (s2, ev2) => this.Show(); // Show TeacherForm again when MainForm closes
            mf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCreateExam form = new FormCreateExam();
            form.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // GradesAnalysisForm analysisForm = new GradesAnalysisForm();
            // analysisForm.Show(); // Or .ShowDialog() as needed
            MessageBox.Show("Here you will see grade analysis: average, past scores, progress, and more.",
                "Grade Analysis",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
