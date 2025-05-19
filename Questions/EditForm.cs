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
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
            LoadQuestions();
            QuestionRepository.LoadFromExcel();

        }

        private void LoadQuestions()
        {
            listBoxQuestions.Items.Clear();

            foreach (var q in QuestionRepository.AllQuestions)
            {
                listBoxQuestions.Items.Add(q.Text);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = listBoxQuestions.SelectedIndex;

            if (index >= 0 && index < QuestionRepository.AllQuestions.Count)
            {
                var selectedQuestion = QuestionRepository.AllQuestions[index];
                new QuestionForm(selectedQuestion, index).ShowDialog();
                LoadQuestions(); // Refresh the list after editing
            }
            else
            {
                MessageBox.Show("Please select a question to edit.");
            }
        }
    }
}
