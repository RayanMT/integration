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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBoxQuestions.SelectedIndex;

            if (index >= 0 && index < QuestionRepository.AllQuestions.Count)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this question?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    QuestionRepository.AllQuestions.RemoveAt(index);
                    QuestionRepository.SaveToExcel();
                    MessageBox.Show("Question deleted successfully.");
                    LoadQuestions(); // Refresh list
                }
            }
            else
            {
                MessageBox.Show("Please select a question to delete.");
            }
        }
    }
}
