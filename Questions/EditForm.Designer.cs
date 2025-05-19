namespace PROJECT
{
    partial class EditForm
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
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.FormattingEnabled = true;
            this.listBoxQuestions.ItemHeight = 25;
            this.listBoxQuestions.Location = new System.Drawing.Point(654, 25);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(400, 179);
            this.listBoxQuestions.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(770, 281);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // EditForm
            // 
            this.ClientSize = new System.Drawing.Size(1906, 656);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.btnEdit);
            this.Name = "EditForm";
            this.Text = "Edit Question";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Button btnEdit;
    }
}
