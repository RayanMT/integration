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
            // Example: open a new practice form or show a message
            MessageBox.Show("Welcome to Test execution!", "Test execution", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Example: opening a new form named PracticeForm
            // PracticeForm practiceForm = new PracticeForm();
            // practiceForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Display grade history using a MessageBox or open a dedicated form
            MessageBox.Show("Your grade history will be displayed here.", "Grade History", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Example, if you have a form named GradesHistoryForm:
            // GradesHistoryForm historyForm = new GradesHistoryForm();
            // historyForm.Show();
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
