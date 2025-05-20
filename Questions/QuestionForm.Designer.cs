namespace PROJECT
{
    partial class QuestionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.comboQuestionType = new System.Windows.Forms.ComboBox();
            this.comboCorrectAnswer = new System.Windows.Forms.ComboBox();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtQuestion
            this.txtQuestion.Location = new System.Drawing.Point(160, 20);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(300, 20);

            // txtA
            this.txtA.Location = new System.Drawing.Point(160, 50);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(300, 20);

            // txtB
            this.txtB.Location = new System.Drawing.Point(160, 80);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(300, 20);

            // txtC
            this.txtC.Location = new System.Drawing.Point(160, 110);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(300, 20);

            // txtD
            this.txtD.Location = new System.Drawing.Point(160, 140);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(300, 20);

            // comboQuestionType
            this.comboQuestionType.Location = new System.Drawing.Point(160, 170);
            this.comboQuestionType.Name = "comboQuestionType";
            this.comboQuestionType.Size = new System.Drawing.Size(200, 21);

            // comboCorrectAnswer
            this.comboCorrectAnswer.Location = new System.Drawing.Point(160, 200);
            this.comboCorrectAnswer.Name = "comboCorrectAnswer";
            this.comboCorrectAnswer.Size = new System.Drawing.Size(200, 21);

            // comboCategory
            this.comboCategory.Location = new System.Drawing.Point(160, 230);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(200, 21);

            // comboDifficulty
            this.comboDifficulty.Location = new System.Drawing.Point(160, 260);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(200, 21);

            // btnAddQuestion
            this.btnAddQuestion.Location = new System.Drawing.Point(180, 300);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(120, 40);
            this.btnAddQuestion.Text = "Add Question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);

            // btnSaveEdit
            this.btnSaveEdit.Location = new System.Drawing.Point(180, 300);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(120, 40);
            this.btnSaveEdit.Text = "Save Edit";
            this.btnSaveEdit.UseVisualStyleBackColor = true;
            this.btnSaveEdit.Visible = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);

            

            // QuestionForm
            this.ClientSize = new System.Drawing.Size(540, 370);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.comboQuestionType);
            this.Controls.Add(this.comboCorrectAnswer);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboDifficulty);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.btnSaveEdit);
            this.Name = "QuestionForm";
            this.Text = "Add/Edit Question";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.ComboBox comboQuestionType;
        private System.Windows.Forms.ComboBox comboCorrectAnswer;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnSaveEdit;
    }
}