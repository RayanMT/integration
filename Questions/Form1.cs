using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserRepository.EnsureFileExists();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form regForm = new Form { Text = "Create New Account", Size = new Size(400, 500), StartPosition = FormStartPosition.CenterScreen };

            Label lblUser = new Label { Text = "Username", Location = new Point(20, 20) };
            TextBox txtUser = new TextBox { Location = new Point(20, 40), Width = 330 };

            Label lblId = new Label { Text = "ID (9 digits)", Location = new Point(20, 70) };
            TextBox txtId = new TextBox { Location = new Point(20, 90), Width = 330 };

            Label lblEmail = new Label { Text = "Email (@gmail.com)", Location = new Point(20, 120) };
            TextBox txtEmail = new TextBox { Location = new Point(20, 140), Width = 330 };

            Label lblPass = new Label { Text = "Password", Location = new Point(20, 170) };
            TextBox txtPass = new TextBox { Location = new Point(20, 190), Width = 330 };

            Label lblRole = new Label { Text = "User Type", Location = new Point(20, 220) };
            RadioButton rbStudent = new RadioButton { Text = "Student", Checked = true, Location = new Point(20, 240) };
            RadioButton rbTeacher = new RadioButton { Text = "Teacher", Location = new Point(120, 240) };

            Button btnRegister = new Button
            {
                Text = "New Account",
                Location = new Point(20, 290),
                Width = 330
            };

            btnRegister.Click += (s, ev) =>
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text;
                string email = txtEmail.Text.Trim();
                string id = txtId.Text.Trim();
                string type = rbStudent.Checked ? "student" : "teacher";

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(id))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(id, @"^\d{9}$"))
                {
                    MessageBox.Show("ID must be exactly 9 digits.");
                    return;
                }

                string emailPattern = @"^[A-Za-z][A-Za-z0-9]*@gmail\.com$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern))
                {
                    MessageBox.Show("Email must be in the format 'example@gmail.com'.");
                    return;
                }

                if (UserRepository.IsUserExists(username, id, email))
                {
                    MessageBox.Show("This username, ID, or email already exists.");
                    return;
                }

                UserRepository.AddUser(username, id, email, password, type);

                MessageBox.Show("Account created successfully!");
                regForm.Close();
            };

            regForm.Controls.AddRange(new Control[]
            {
                lblUser, txtUser,
                lblId, txtId,
                lblPass, txtPass,
                lblEmail, txtEmail,
                lblRole, rbStudent, rbTeacher,
                btnRegister
            });

            regForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string role = comboBoxUserType.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("יש למלא את כל השדות החובה!", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValid = UserRepository.ValidateLogin(username, password, role);

            if (isValid)
            {
                this.Hide();
                if (role == "student")
                {
                    var smf = new StudentMainForm();
                    smf.FormClosed += (s2, ev2) => this.Close();
                    smf.Show();
                }
                else
                {
                    var tf = new TeacherForm();
                    tf.FormClosed += (s2, ev2) => this.Close();
                    tf.Show();
                }
            }
            else
            {
                MessageBox.Show("פרטי ההתחברות שגויים. נסה שוב.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            // You can leave it empty or include validation logic
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Optional: add tooltip or interaction if you want
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: logic based on selected role (student / teacher)
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Optional: add logic if needed
            TextBox txt = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.BackColor = Color.MistyRose;
            }
            else
            {
                txt.BackColor = Color.White;
            }
        }


    }

}
