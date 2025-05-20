using ExamSystemApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class ExamForm : Form
    {
        private List<Question> questions;
        private Dictionary<int, int> userAnswers = new Dictionary<int, int>();
        private int currentIndex = 0;
        private string difficulty = "Easy";
        private string selectedCourse = "Algorithms";
        private int totalExamSeconds = 600;
        private int timeLeft;
        private Timer examTimer;

        public ExamForm()
        {
            InitializeComponent();
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            QuestionRepository.LoadFromExcel();
            var allQs = QuestionRepository.AllQuestions;


            if (allQs.Count == 0)
            {
                MessageBox.Show("No questions loaded. Excel file may be empty or invalid.");
                this.Close();
                return;
            }

            questions = allQs
                .Where(q => q.Difficulty == difficulty && q.Category == selectedCourse)
                .OrderBy(_ => Guid.NewGuid())
                .Take(4)
                .ToList();

            if (questions.Count < 4)
            {
                MessageBox.Show("Not enough questions for this difficulty and course.");
                this.Close();
                return;
            }

            timeLeft = totalExamSeconds;
            examTimer = new Timer();
            examTimer.Interval = 1000;
            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();

            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }

        private void DisplayQuestion(int index)
        {
            var q = questions[index];
            labelQuestionNumber.Text = $"Question {index + 1} of {questions.Count}";
            labelQ1.Text = q.Text;
            Course.Text = $"{q.Category} Exam - {q.Difficulty} Level";

            radioA.Text = q.AnswerA;
            radioB.Text = q.AnswerB;
            radioC.Text = q.AnswerC;
            radioD.Text = q.AnswerD;

            radioA.Checked = radioB.Checked = radioC.Checked = radioD.Checked = false;

            if (userAnswers.ContainsKey(index))
            {
                switch (userAnswers[index])
                {
                    case 0: radioA.Checked = true; break;
                    case 1: radioB.Checked = true; break;
                    case 2: radioC.Checked = true; break;
                    case 3: radioD.Checked = true; break;
                }
            }

            bool isTrueFalse = string.IsNullOrWhiteSpace(q.AnswerC) && string.IsNullOrWhiteSpace(q.AnswerD);
            radioC.Visible = radioD.Visible = !isTrueFalse;
        }


        private void SaveAnswer()
        {
            int selected = GetSelectedOption();
            if (selected != -1)
                userAnswers[currentIndex] = selected;
        }

        private int GetSelectedOption()
        {
            if (radioA.Checked) return 0;
            if (radioB.Checked) return 1;
            if (radioC.Checked) return 2;
            if (radioD.Checked) return 3;
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetSelectedOption() == -1)
            {
                MessageBox.Show("Please select an answer before proceeding.");
                return;
            }

            SaveAnswer();
            currentIndex++;
            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            currentIndex--;
            DisplayQuestion(currentIndex);
            UpdateNavigationButtons();
        }

        private void SubmitExam()
        {
            if (GetSelectedOption() == -1)
            {
                MessageBox.Show("Please select an answer before submitting.");
                return;
            }

            SaveAnswer();
            examTimer.Stop();

            int score = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                if (userAnswers.TryGetValue(i, out int selected))
                {
                    string selectedAnswer = selected switch
                    {
                        0 => questions[i].AnswerA,
                        1 => questions[i].AnswerB,
                        2 => questions[i].AnswerC,
                        3 => questions[i].AnswerD,
                        _ => ""
                    };

                    if (selectedAnswer == questions[i].CorrectAnswer)
                        score += 25;
                }

            }

            MessageBox.Show($"Exam finished!\nYour score: {score} / 100", "Result");
            int minutesTaken = (totalExamSeconds - timeLeft) / 60;

            ExcelManager.SaveExamResult(
                ExcelFiles.Results,
                "S02", selectedCourse, difficulty, score, minutesTaken, totalExamSeconds / 60
            );

            this.Close();
        }

        private void UpdateNavigationButtons()
        {
            button2.Visible = currentIndex > 0;

            if (currentIndex == questions.Count - 1)
            {
                button1.Text = "Submit";
                button1.Click -= button1_Click;
                button1.Click += (s, e) => SubmitExam();
            }
            else
            {
                button1.Text = "Next ->";
                button1.Click -= (s, e) => SubmitExam();
                button1.Click -= button1_Click;
                button1.Click += button1_Click;
            }
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            TimeSpan t = TimeSpan.FromSeconds(timeLeft);
            this.Text = $"Time Left: {t:mm\\:ss}";

            if (timeLeft <= 0)
            {
                examTimer.Stop();
                MessageBox.Show("Time is up! The exam will be submitted.");
                SubmitExam();
            }
        }

        // 🔧 Empty event handlers for Designer wiring
        private void labelQ1_Click(object sender, EventArgs e) { }
        private void radioA_CheckedChanged(object sender, EventArgs e) { }
        private void radioC_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton4_CheckedChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
