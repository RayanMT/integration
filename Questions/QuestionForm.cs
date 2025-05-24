using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace PROJECT
{
    public partial class QuestionForm : Form
    {
        private List<Question> questions = QuestionRepository.AllQuestions;
        private bool isEditMode = false;
        private int editIndex = -1;

        public QuestionForm()
        {
            InitializeComponent();
            InitializeDropdowns();
            comboQuestionType.SelectedIndexChanged += comboQuestionType_SelectedIndexChanged;
            btnSaveEdit.Visible = false;
        }

        public QuestionForm(Question q, int index) : this()
        {
            isEditMode = true;
            editIndex = index;

            comboQuestionType.SelectedItem = q.Type;
            txtQuestion.Text = q.Text;
            txtA.Text = q.AnswerA;
            txtB.Text = q.AnswerB;
            txtC.Text = q.AnswerC;
            txtD.Text = q.AnswerD;
            comboCorrectAnswer.Text = q.CorrectAnswer;
            comboCategory.SelectedItem = q.Category;
            comboDifficulty.SelectedItem = q.Difficulty;

            btnAddQuestion.Visible = false;
            btnSaveEdit.Visible = true;
        }

        private void InitializeDropdowns()
        {
            comboQuestionType.Items.AddRange(new string[] { "MultipleChoice", "YesNo", "FillInBlank" });
            comboQuestionType.SelectedIndex = 0;

            comboCorrectAnswer.Items.AddRange(new string[] { "A", "B", "C", "D" });
            comboCorrectAnswer.SelectedIndex = 0;

            comboCategory.Items.AddRange(new string[] { "Algorithms", "Databases", "Testing" });
            comboCategory.SelectedIndex = 0;

            comboDifficulty.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });
            comboDifficulty.SelectedIndex = 0;
        }

        private void comboQuestionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboQuestionType.SelectedItem.ToString();
            bool isMCQ = selectedType == "MultipleChoice";
            bool isYesNo = selectedType == "YesNo";
            bool isFillBlank = selectedType == "FillInBlank";

            txtA.Visible = isMCQ;
            txtB.Visible = isMCQ;
            txtC.Visible = isMCQ;
            txtD.Visible = isMCQ;

            comboCorrectAnswer.Items.Clear();

            if (isMCQ)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
                comboCorrectAnswer.Items.AddRange(new string[] { "A", "B", "C", "D" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (isYesNo)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDownList;
                comboCorrectAnswer.Items.AddRange(new string[] { "Yes", "No" });
                comboCorrectAnswer.SelectedIndex = 0;
            }
            else if (isFillBlank)
            {
                comboCorrectAnswer.DropDownStyle = ComboBoxStyle.DropDown;
                comboCorrectAnswer.Text = "";
            }
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out Question q)) return;

            questions.Add(q);
            QuestionRepository.SaveToExcel();
            ClearInputs();

            MessageBox.Show("The question is added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs(out Question updated)) return;

            if (editIndex >= 0 && editIndex < questions.Count)
            {
                questions[editIndex] = updated;
                QuestionRepository.SaveToExcel();
                MessageBox.Show("Question updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool ValidateInputs(out Question result)
        {
            result = null;
            string selectedType = comboQuestionType.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(txtQuestion.Text))
            {
                MessageBox.Show("Please fill in the question.");
                return false;
            }

            if (selectedType == "MultipleChoice")
            {
                if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text) ||
                    string.IsNullOrWhiteSpace(txtC.Text) || string.IsNullOrWhiteSpace(txtD.Text))
                {
                    MessageBox.Show("Please fill in all options for Multiple Choice.");
                    return false;
                }
            }

            if (selectedType == "YesNo")
            {
                txtA.Text = "Yes";
                txtB.Text = "No";
                txtC.Text = "";
                txtD.Text = "";
            }

            if (selectedType == "FillInBlank")
            {
                txtA.Text = "";
                txtB.Text = "";
                txtC.Text = "";
                txtD.Text = "";
            }

            string correctAnswer;
            if (selectedType == "FillInBlank")
            {
                correctAnswer = comboCorrectAnswer.Text.Trim();
                if (string.IsNullOrWhiteSpace(correctAnswer))
                {
                    MessageBox.Show("Please enter the correct answer for Fill In The Blank.");
                    return false;
                }
            }
            else
            {
                if (comboCorrectAnswer.SelectedItem == null)
                {
                    MessageBox.Show("Please select a correct answer.");
                    return false;
                }
                correctAnswer = comboCorrectAnswer.SelectedItem.ToString();
            }

            result = new Question
            {
                Type = selectedType,
                Text = txtQuestion.Text,
                AnswerA = txtA.Text,
                AnswerB = txtB.Text,
                AnswerC = txtC.Text,
                AnswerD = txtD.Text,
                CorrectAnswer = correctAnswer,
                Category = comboCategory.SelectedItem?.ToString() ?? "",
                Difficulty = comboDifficulty.SelectedItem?.ToString() ?? ""
            };

            return true;
        }

        private void ClearInputs()
        {
            txtQuestion.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            comboCategory.SelectedIndex = 0;
            comboDifficulty.SelectedIndex = 0;
            comboQuestionType.SelectedIndex = 0;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Next clicked!");
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prev clicked!");
        }
    }
}
