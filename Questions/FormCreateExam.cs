// FormCreateExam.cs - גרסה חדשה: שימוש ב-QuestionRepository במקום Excel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PROJECT; // ייבוא המחלקות שלהם

namespace ExamSystem_New
{
    public partial class FormCreateExam : Form
    {
        private List<Question> filteredExamQuestions = new List<Question>();

        public FormCreateExam()
        {
            InitializeComponent();

            comboCategory.Items.AddRange(new string[] {
                "Algorithms", "Databases", "Testing"
            });

            comboDifficulty.Items.AddRange(new string[] {
                "Easy", "Medium", "Hard"
            });

            comboCategory.SelectedIndex = 0;
            comboDifficulty.SelectedIndex = 0;
        }

        private void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            string category = comboCategory.SelectedItem?.ToString();
            string difficulty = comboDifficulty.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(difficulty))
            {
                MessageBox.Show("Please select both category and difficulty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var allQuestions = QuestionRepository.AllQuestions;
            if (allQuestions == null || allQuestions.Count == 0)
            {
                MessageBox.Show("No questions available in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dgvExam.DataSource = allQuestions
                .Where(q => q.Category == category && q.Difficulty == difficulty)
                .ToList();

            MessageBox.Show("Questions loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGenerateExam_Click(object sender, EventArgs e)
        {
            string category = comboCategory.SelectedItem?.ToString();
            string difficulty = comboDifficulty.SelectedItem?.ToString();

            if (!int.TryParse(txtNumQuestions.Text, out int numQuestions) || numQuestions <= 0)
            {
                MessageBox.Show("Please enter a valid positive number of questions.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var allQuestions = QuestionRepository.AllQuestions;
            var filtered = allQuestions
                .Where(q => q.Category == category && q.Difficulty == difficulty)
                .ToList();

            if (filtered.Count < numQuestions)
            {
                MessageBox.Show($"Only {filtered.Count} questions are available for the selected filters.", "Too Many Questions", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            filteredExamQuestions = filtered.OrderBy(x => Guid.NewGuid()).Take(numQuestions).ToList();
            dgvExam.DataSource = filteredExamQuestions;
        }

        private void btnSaveExam_Click(object sender, EventArgs e)
        {
            if (filteredExamQuestions.Count == 0)
            {
                MessageBox.Show("No exam to save.", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // אופציונלי: שמירה לקובץ חדש או שימוש בשיטה קיימת אצלם
            QuestionRepository.SaveToExcel();
            MessageBox.Show("Exam saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvExam.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one question to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var toDelete = new List<Question>();
            foreach (DataGridViewRow row in dgvExam.SelectedRows)
            {
                if (row.DataBoundItem is Question selectedQuestion)
                {
                    toDelete.Add(selectedQuestion);
                }
            }

            foreach (var q in toDelete)
            {
                QuestionRepository.AllQuestions.Remove(q);
            }

            dgvExam.DataSource = null;
            dgvExam.DataSource = QuestionRepository.AllQuestions;
        }

        private void btnViewExams_Click(object sender, EventArgs e)
        {
            dgvExam.DataSource = QuestionRepository.AllQuestions;
        }
    }
}
