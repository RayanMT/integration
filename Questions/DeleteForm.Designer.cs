namespace PROJECT
{
    partial class DeleteForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.FormattingEnabled = true;
            this.listBoxQuestions.ItemHeight = 25;
            this.listBoxQuestions.Location = new System.Drawing.Point(606, 38);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.Size = new System.Drawing.Size(400, 179);
            this.listBoxQuestions.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(734, 278);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DeleteForm
            // 
            this.ClientSize = new System.Drawing.Size(1924, 759);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.btnDelete);
            this.Name = "DeleteForm";
            this.Text = "Delete Question";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Button btnDelete;
    }
}
