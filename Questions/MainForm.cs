﻿using DocumentFormat.OpenXml.Bibliography;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new QuestionForm().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            new DeleteForm().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditForm().ShowDialog();
        }

        public void OpenAddQuestion()
        {
            btnAdd.PerformClick();
        }

    }
}
