using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }


        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) || 
                string.IsNullOrWhiteSpace(txtFullName.Text) || 
                string.IsNullOrWhiteSpace(txtEmail.Text) || 
                cmbProgramme.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Safe Numeric Parsing (Exception Handling for Age)
            if (!int.TryParse(txtAge.Text, out int parsedAge))
            {
                MessageBox.Show("Please enter a valid numeric value for Age.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAge.Focus();
                return;
            }

            // 3. Logic Validation (Range Check)
            if (parsedAge < 16 || parsedAge > 100)
            {
                MessageBox.Show("Please enter a realistic age (between 16 and 100).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentional weak validation for testing purposes
            Student student = new Student
            {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Age = parsedAge,
                Programme = cmbProgramme.Text
            };

            txtStudentOutput.Text =
                "Student saved successfully!" + Environment.NewLine +
                "Student ID: " + student.StudentId + Environment.NewLine +
                "Full Name: " + student.FullName + Environment.NewLine +
                "Email: " + student.Email + Environment.NewLine +
                "Age: " + student.Age + Environment.NewLine +
                "Programme: " + student.Programme;
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
