// FormCreateExam.Designer.cs (גרסה סופית, יציבה, מתוקנת)
namespace ExamSystem_New
{
    partial class FormCreateExam
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboDifficulty = new System.Windows.Forms.ComboBox();
            this.txtNumQuestions = new System.Windows.Forms.TextBox();
            this.dgvExam = new System.Windows.Forms.DataGridView();
            this.btnLoadQuestions = new System.Windows.Forms.Button();
            this.btnGenerateExam = new System.Windows.Forms.Button();
            this.btnSaveExam = new System.Windows.Forms.Button();
            this.btnViewExams = new System.Windows.Forms.Button();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblNumQuestions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).BeginInit();
            this.SuspendLayout();

            // comboCategory
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(180, 30);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(200, 23);

            // comboDifficulty
            this.comboDifficulty.FormattingEnabled = true;
            this.comboDifficulty.Location = new System.Drawing.Point(180, 70);
            this.comboDifficulty.Name = "comboDifficulty";
            this.comboDifficulty.Size = new System.Drawing.Size(200, 23);

            // txtNumQuestions
            this.txtNumQuestions.Location = new System.Drawing.Point(180, 110);
            this.txtNumQuestions.Name = "txtNumQuestions";
            this.txtNumQuestions.Size = new System.Drawing.Size(200, 23);

            // dgvExam
            this.dgvExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExam.Location = new System.Drawing.Point(30, 160);
            this.dgvExam.Name = "dgvExam";
            this.dgvExam.Size = new System.Drawing.Size(740, 250);

            // btnLoadQuestions
            this.btnLoadQuestions.Location = new System.Drawing.Point(400, 30);
            this.btnLoadQuestions.Name = "btnLoadQuestions";
            this.btnLoadQuestions.Size = new System.Drawing.Size(150, 23);
            this.btnLoadQuestions.Text = "Load Questions";
            this.btnLoadQuestions.UseVisualStyleBackColor = true;
            this.btnLoadQuestions.Click += new System.EventHandler(this.btnLoadQuestions_Click);

            // btnGenerateExam
            this.btnGenerateExam.Location = new System.Drawing.Point(400, 70);
            this.btnGenerateExam.Name = "btnGenerateExam";
            this.btnGenerateExam.Size = new System.Drawing.Size(150, 23);
            this.btnGenerateExam.Text = "Generate Exam";
            this.btnGenerateExam.UseVisualStyleBackColor = true;
            this.btnGenerateExam.Click += new System.EventHandler(this.btnGenerateExam_Click);

            // btnSaveExam
            this.btnSaveExam.Location = new System.Drawing.Point(400, 110);
            this.btnSaveExam.Name = "btnSaveExam";
            this.btnSaveExam.Size = new System.Drawing.Size(150, 23);
            this.btnSaveExam.Text = "Save Exam";
            this.btnSaveExam.UseVisualStyleBackColor = true;
            this.btnSaveExam.Click += new System.EventHandler(this.btnSaveExam_Click);

            // btnViewExams
            this.btnViewExams.Location = new System.Drawing.Point(180, 430);
            this.btnViewExams.Name = "btnViewExams";
            this.btnViewExams.Size = new System.Drawing.Size(150, 23);
            this.btnViewExams.Text = "View Saved Exams";
            this.btnViewExams.UseVisualStyleBackColor = true;
            this.btnViewExams.Click += new System.EventHandler(this.btnViewExams_Click);

            // btnDeleteSelected
            this.btnDeleteSelected.Location = new System.Drawing.Point(340, 430);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(150, 23);
            this.btnDeleteSelected.Text = "Delete Selected Exam";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);

            // lblCategory
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(80, 33);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Text = "Category:";

            // lblDifficulty
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(80, 73);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Text = "Difficulty:";

            // lblNumQuestions
            this.lblNumQuestions.AutoSize = true;
            this.lblNumQuestions.Location = new System.Drawing.Point(80, 113);
            this.lblNumQuestions.Name = "lblNumQuestions";
            this.lblNumQuestions.Text = "Number of Questions:";

            // FormCreateExam
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.comboDifficulty);
            this.Controls.Add(this.txtNumQuestions);
            this.Controls.Add(this.btnLoadQuestions);
            this.Controls.Add(this.btnGenerateExam);
            this.Controls.Add(this.btnSaveExam);
            this.Controls.Add(this.btnViewExams);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.dgvExam);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDifficulty);
            this.Controls.Add(this.lblNumQuestions);
            this.Name = "FormCreateExam";
            this.Text = "Create Exam Screen";
            ((System.ComponentModel.ISupportInitialize)(this.dgvExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboDifficulty;
        private System.Windows.Forms.TextBox txtNumQuestions;
        private System.Windows.Forms.DataGridView dgvExam;
        private System.Windows.Forms.Button btnLoadQuestions;
        private System.Windows.Forms.Button btnGenerateExam;
        private System.Windows.Forms.Button btnSaveExam;
        private System.Windows.Forms.Button btnViewExams;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblNumQuestions;
    }
}
